using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public partial class Manager
    {
        // **** Addition
        public List<Addition> GetAllAddtion()
            => dal.GetAllAddtion();

        // **** Customer
        public Customer GetCustomer(string email)
            => dal.GetCustomer(email);

        // **** CustomerType
        public List<CustomerType> GetCustomerTypes(int orderNumber)
            => dal.GetCustomerType(orderNumber);

        public void CreateCustomerTypes(int orderNumber, CustomerType value)
            => dal.CreateCustomerTypes(orderNumber, value);

        // **** Reservation
        public Reservation GetReservation(int orderNumber)
            => dal.GetReservation(orderNumber);

        public List<Reservation> GetAllReservationsWithMissingInvoice()
            => dal.GetAllReservationsWithMissingInvoice();

        public void MarkReservationAsSent(int orderNumber)
            => dal.MarkReservationAsSent(orderNumber);

        // **** Spot
        public Spot GetSpot(string spotNumber)
            => dal.GetSpot(spotNumber);
    }
}
