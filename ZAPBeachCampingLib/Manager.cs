using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public class Manager
    {
        private DataAccess dal = new DataAccess();

        #region Addition
        public List<Addition> GetAllAddtion()
        {
            return dal.GetAllAddtion();
        }
        #endregion

       

        #region Customers

        public Customer GetCustomer(string email)
        {
            return dal.GetCustomer(email);
        }
        #endregion

        #region CustomerTypes

        public List<CustomerType> GetCustomerType(int orderNumber)
        {

            //return dal.GetCustomerType(orderNumber);
            List<CustomerType> customerTypes = new List<CustomerType>();

            foreach (CustomerType customerType in dal.GetCustomerType(orderNumber))
            {
                customerTypes.Add(customerType);
            }
            return customerTypes;
        }

        public void CreateCustomerTypes(int orderNumber, CustomerType value)
        {
            dal.CreateCustomerTypes(orderNumber, value);
        }



        #endregion

        #region ReservationAddition

        #endregion

        #region Reservation
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach (Reservation reservation in dal.GetAllReservationsWithMissingInvoice())
            {
                reservations.Add(GetReservations(reservation.OrderNumber));
            }
            return reservations;
        }


        public Reservation GetReservations(int orderNumber)
        {
            Reservation reservation = dal.GetReservations(orderNumber);
            reservation.Customer = GetCustomer(reservation.CustomerEmail);

            reservation.CustomerTypes = GetCustomerType(reservation.OrderNumber);


            //reservation.Additions = GetAllAddtion();

            //reservation.CustomerTypes = Mangler
            //reservation.Additions = Mangler
            // reservation.Spot = Mangler, vent til i morgen
            return reservation;
        }

        public Reservation MarkReservationAsSent(int orderNumber)
        {
            // Det samme gælder her, du retunere kun noget af reservations objektet
            return dal.MarkReservationAsSent(orderNumber);
        }
        #endregion
    }
}
