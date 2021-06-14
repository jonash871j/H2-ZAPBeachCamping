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



        #endregion

        #region ReservationAddition

        #endregion

        #region Reservation
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {
            return dal.GetAllReservationsWithMissingInvoice();
        }


        public Reservation GetReservations(int orderNumber)
        {
            Reservation reservation = dal.GetReservations(orderNumber);
            reservation.Customer = GetCustomer(reservation.CustomerEmail);
            return reservation;
        }

        public Reservation MarkReservationAsSent(int orderNumber)
        {
            return dal.MarkReservationAsSent(orderNumber);
        }
        #endregion
    }
}
