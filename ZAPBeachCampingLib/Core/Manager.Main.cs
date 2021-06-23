using System.Collections.Generic;

namespace ZAPBeachCampingLib.Core
{
    public partial class Manager
    {
        private DataAccess dal;
        public event MessageEventHandler MissingInformation;

        public Manager()
        {
            dal = new DataAccess();
        }

        // **** Addition
        public List<Addition> GetAllAddtion()
            => dal.GetAllAddition();

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

        // **** Spot
        public Spot GetSpot(string spotNumber)
            => dal.GetSpot(spotNumber);
    }
}
