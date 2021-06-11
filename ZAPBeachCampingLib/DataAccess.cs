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
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {
            using (IDbConnection connection = new SqlConnection(CONNECTION))
            {
                var output = connection.Query<Reservation>("GetAllReservationsWithMissingInvoice").ToList();
                return output;
            }
        }

        public Reservation GetReservations(int orderNumber)
        {
            using (IDbConnection connection = new SqlConnection(CONNECTION))
            {
                return connection.Query<Reservation>("GetReservation @OrderNumber", new Reservation { OrderNumber = orderNumber}).FirstOrDefault();
            }
        }

        public Customer GetCustomer(string email)
        {
            return GetDB((c) => c.Query<Customer>("GetCustomer @Email", new Customer { Email = email }).FirstOrDefault());
            //using (IDbConnection connection = new SqlConnection(CONNECTION))
            //{
            //    return connection.Query<Customer>("GetCustomer @Email", new Customer { Email = email}).FirstOrDefault();
            //}
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
