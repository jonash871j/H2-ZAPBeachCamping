using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    internal class DataAccess
    {

        private const string CONNECTION = "Server=ZBC-E-RO-23239\\MSSQLSERVER01;Database=Website;Trusted_Connection=True;";


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

        #region Reservation
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {

            return GetDB((c) => c.Query<Reservation>("GetAllReservationsWithMissingInvoice").ToList());
        }

        public Reservation GetReservations(int orderNumber)
        {
            return GetDB((c) => c.Query<Reservation>("GetReservation @OrderNumber", new Reservation { OrderNumber = orderNumber }).FirstOrDefault());
        }

        public Reservation MarkReservationAsSent(int orderNumber)
        {
            return GetDB((c) => c.Query<Reservation>("MarkReservationAsSent @OrderNumber", new Reservation { OrderNumber = orderNumber }).FirstOrDefault());
        }
        #endregion

        // Prøv at teste om dette virker, er ikke sikker
        public void CreateCustomerTypes(int orderNumber, CustomerType customerType)
        {
            GetDB((c) => c.Query<CustomerType>("CreateCustomerType @OrderNumber @CustomerType,  @Value", new { OrderNumber = orderNumber, CustomerType = (int)customerType }));
        }

        private T GetDB<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection c = new SqlConnection(CONNECTION))
            {
                return func(c);
            }
        }
    }
}
