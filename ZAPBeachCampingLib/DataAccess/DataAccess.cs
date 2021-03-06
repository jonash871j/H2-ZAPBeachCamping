using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ZAPBeachCampingLib.Core;

namespace ZAPBeachCampingLib
{
    internal class DataAccess
    {
        private string connectionString;

        internal DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        // **** Additions
        internal List<Addition> GetAllAddition()
            => GetDB((c) => c.Query<Addition>("GetAllAdditions").ToList());

        // **** Customer
        internal Customer GetCustomer(string email)
            => GetDB((c) => c.Query<Customer>("GetCustomer @Email", new Customer { Email = email }).FirstOrDefault());

        // ****  CustomerTypes
        internal List<CustomerType> GetCustomerType(int orderNumber)
            => GetDB((c) => c.Query<CustomerType>("GetCustomerType @OrderNumber", new { OrderNumber = orderNumber }).ToList());

        internal void CreateCustomerTypes(int orderNumber, CustomerType value)
            => GetDB((c) => c.Query<CustomerType>("CreateCustomerType @OrderNumber,  @Value", new { OrderNumber = orderNumber, Value = (int)value }));

        // **** ReservationAdditions
        internal void CreateReservationAdditions(int orderNumber, string additionName)
            => GetDB((c) => c.Query<Addition>("CreateReservationAdditions @OrderNumber, @AdditionName", new { OrderNumber = orderNumber, AdditionName = additionName })).ToList();

        internal List<Addition> GetReservationAdditions(int orderNumber)
            => GetDB((c) => c.Query<Addition>("GetReservationAdditions @OrderNumber", new { OrderNumber = orderNumber })).ToList();

        // **** Reservation
        internal void CreateReservation(Reservation reservation)
        {
            GetDB(con =>
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", reservation.Customer.Email);
                parameters.Add("Firstname", reservation.Customer.FirstName);
                parameters.Add("LastName", reservation.Customer.LastName);
                parameters.Add("City", reservation.Customer.City);
                parameters.Add("Address", reservation.Customer.Address);
                parameters.Add("PhoneNumber", reservation.Customer.PhoneNumber);
                parameters.Add("SpotNumber", reservation.Spot.Number);
                parameters.Add("StartDate", reservation.StartDate);
                parameters.Add("EndDate", reservation.EndDate);
                parameters.Add("IsPayForCleaning", reservation.IsPayForCleaning);
                parameters.Add("SeasonType", reservation.SeasonType);
                parameters.Add("OrderNumber", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute("CreateReservation", parameters, commandType: CommandType.StoredProcedure);

                reservation.OrderNumber = parameters.Get<int>("OrderNumber");
            });

            foreach (CustomerType customerType in reservation.CustomerTypes)
            {
                CreateCustomerTypes(reservation.OrderNumber, customerType);
            }
            foreach (Addition addition in reservation.Additions)
            {
                CreateReservationAdditions(reservation.OrderNumber, addition.Name);
            }
        }

        internal Reservation GetReservation(int orderNumber)
        {
            Reservation reservation = GetDB((c) => c.Query<Reservation>("GetReservation @OrderNumber", new { OrderNumber = orderNumber }).FirstOrDefault());
            reservation.Customer = GetCustomer(reservation.CustomerEmail);
            reservation.CustomerTypes = GetCustomerType(reservation.OrderNumber);
            reservation.Additions = GetReservationAdditions(orderNumber);
            reservation.Spot = GetSpot(reservation.SpotNumber);

            return reservation;
        }

        internal List<Reservation> GetAllReservationsWithMissingInvoice()
            => GetDB(c => c.Query<Reservation>("GetAllReservationsWithMissingInvoice").ToList());

        internal void MarkInvoiceAsSent(int orderNumber)
            => GetDB(c => c.Query<Reservation>("MarkInvoiceAsSent @OrderNumber", new { OrderNumber = orderNumber }).FirstOrDefault());

        // **** Spots
        internal List<Spot> GetSpotsBySearch(SpotType spotType, CampingType campingType, HutType hutType, bool isGoodView)
        {
            switch (spotType)
            {
                case SpotType.TentSite:
                    return new List<Spot>(GetDB(c => c.Query<TentSpot>("GetSiteBySearch @IsGoodView", new { IsGoodView = isGoodView }).ToList()));
                case SpotType.CampingSite:
                    return new List<Spot>(GetDB(c => c.Query<CampingSpot>("GetCampingSiteBySearch @IsGoodView, @CampingType", new { IsGoodView = isGoodView, CampingType = (int)campingType }).ToList()));
                case SpotType.HutSite:
                    return new List<Spot>(GetDB(c => c.Query<HutSpot>("GetHutSiteBySearch @IsGoodView, @HutType", new { IsGoodView = isGoodView, HutType = (int)hutType }).ToList()));
                default:
                    return null;
            }
        }

        internal Spot GetSpot(string spotNumber)
        {
            Spot spot = GetDB(c => c.Query<TentSpot>("GetSite @Number", new { Number = spotNumber }).FirstOrDefault());

            switch (spot.SpotType)
            {
                case SpotType.TentSite:
                    return (GetDB(c => c.Query<TentSpot>("GetSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                case SpotType.CampingSite:
                    return (GetDB(c => c.Query<CampingSpot>("GetCampingSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                case SpotType.HutSite:
                    return (GetDB(c => c.Query<HutSpot>("GetHutSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                default:
                    return null;
            }
        }

        internal List<string> GetAllUnavailbleSpotNumbersBetweenDate(DateTime startDate, DateTime endDate)
        {
            return GetDB(c => c.Query<string>("GetAllSpotNumbersBetweenDate @StartDate, @EndDate", new { StartDate = startDate, EndDate = endDate }).ToList());
        }
        internal SpotStatus GetSpotStatus(string spotNumber)
        {
            return GetDB(con =>
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SpotNumber", spotNumber);
                parameters.Add("SpotStatus", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute("GetSpotStatus", parameters, commandType: CommandType.StoredProcedure);

                return (SpotStatus)parameters.Get<int>("SpotStatus");
            });
        }

        // **** Other

        private T GetDB<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection c = new SqlConnection(connectionString))
            {
                return func(c);
            }
        }
        private void GetDB(Action<IDbConnection> func)
        {
            using (IDbConnection c = new SqlConnection(connectionString))
            {
                func(c);
            }
        }
    }
}
