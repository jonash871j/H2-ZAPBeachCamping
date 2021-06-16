﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public delegate void ErrorEventHandler(string message);

    internal class DataAccess
    {
        internal event ErrorEventHandler DataAccessFailure; 
        //private const string CONNECTION = "Server=ZBC-E-RO-23239\\MSSQLSERVER01;Database=Website;Trusted_Connection=True;";
        private const string CONNECTION = "Server=DK-ECI-JHH\\SQLEXPRESS;Database=ZAPBeachCamping;Trusted_Connection=True;";


        #region Additions
        public List<Addition> GetAllAddtion()
        {
            return GetDB((c) => c.Query<Addition>("GetAllAddtions").ToList());
        }
        #endregion

        #region Customer

        public Customer GetCustomer(string email)
        {
            return GetDB((c) => c.Query<Customer>("GetCustomer @Email", new Customer { Email = email }).FirstOrDefault());
        }
        #endregion

        #region CustomerTypes

        public List<CustomerType> GetCustomerType(int orderNumber)
        {
            return GetDB((c) => c.Query<CustomerType>("GetCustomerType @OrderNumber", new { OrderNumber = orderNumber }).ToList());
        }

        public void CreateCustomerTypes(int orderNumber, CustomerType value)
        {
            GetDB((c) => c.Query<CustomerType>("CreateCustomerType @OrderNumber,  @Value", new { OrderNumber = orderNumber, Value = (int)value }));
        }
        #endregion


        #region ReservationAdditions

        public List<Addition> GetReservationAdditions(int orderNumber)
        {
            return GetDB((c) => c.Query<Addition>("GetReservationAdditions @OrderNumber", new { OrderNumber = orderNumber })).ToList();
        }
        #endregion

        #region Reservation
        public void CreateReservation(Reservation reservation)
        {
            Reservation r = reservation;
            Customer c = reservation.Customer;
            Spot s = reservation.Spot;

            GetDB(con => con.Query<Reservation>("CreateReservation @Email, @Firstname, " +
                "@LastName, @City, @Address, @PhoneNumber, @SpotNumber, @TotalPrice, @StartDate, @EndDate", 
                new { Email = c.Email, FirstName = c.FirstName, LastName = c.LastName,
                City = c.City, Address = c.Address, PhoneNumber = c.PhoneNumber, SpotNumber = s.Number, r.TotalPrice, r.StartDate, r.EndDate}));
        }
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {
            return GetDB((c) => c.Query<Reservation>("GetAllReservationsWithMissingInvoice").ToList());
        }

        public Reservation GetReservation(int orderNumber)
        {
            return GetDB((c) => c.Query<Reservation>("GetReservation @OrderNumber", new { OrderNumber = orderNumber }).FirstOrDefault());
        }

        public void MarkReservationAsSent(int orderNumber)
        {
            GetDB((c) => c.Query<Reservation>("MarkReservationAsSent @OrderNumber", new { OrderNumber = orderNumber }).FirstOrDefault());
        }
        #endregion


        #region Spots

        public List<Spot> GetSpotsBySearch(SpotType spotType, bool isGoodView)
        {
            switch (spotType)
            {
                case SpotType.TentSite:
                    return new List<Spot>(GetDB((c) => c.Query<TentSpot>("GetSiteBySearch @IsGoodView", new { IsGoodView = isGoodView }).ToList()));
                case SpotType.CampingSite:
                    return new List<Spot>(GetDB((c) => c.Query<CampingSpot>("GetCampingSiteBySearch @IsGoodView", new { IsGoodView = isGoodView }).ToList()));
                case SpotType.HutSite:
                    return new List<Spot>(GetDB((c) => c.Query<HutSpot>("GetHutSiteBySearch @IsGoodView", new { IsGoodView = isGoodView }).ToList()));
                default:
                    return null;
            }
        }
        public Spot GetSpot(string spotNumber)
        {
            Spot spot = GetDB((c) => c.Query<TentSpot>("GetSite @Number", new { Number = spotNumber }).FirstOrDefault());

            switch (spot.SpotType)
            {
                case SpotType.TentSite:
                    return (GetDB((c) => c.Query<TentSpot>("GetSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                case SpotType.CampingSite:
                    return (GetDB((c) => c.Query<CampingSpot>("GetCampingSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                case SpotType.HutSite:
                    return (GetDB((c) => c.Query<HutSpot>("GetHutSite @Number", new { Number = spotNumber }).FirstOrDefault()));
                default:
                    return null;
            }
        }

        public List<string> GetAllUnavailbleSpotNumbersBetweenDate(DateTime startDate, DateTime endDate)
        {
            return GetDB((c) => c.Query<string>("GetAllSpotNumbersBetweenDate @StartDate, @EndDate", new { StartDate = startDate, EndDate = endDate }).ToList());
        }

        #endregion

        private T GetDB<T>(Func<IDbConnection, T> func)
        {
            try
            {
                using (IDbConnection c = new SqlConnection(CONNECTION))
                {
                    return func(c);
                }
            }
            catch(Exception exception)
            {
                DataAccessFailure?.Invoke("Fatal data access failure: " + exception.Message);
                return default(T);
            }
        }
    }
}
