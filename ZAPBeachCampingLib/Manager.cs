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
            // Lige nu retunere du kun noget af reservations objektet,
            // Du bliver nødt til at kalde GetReservation for hver reservation
            return dal.GetAllReservationsWithMissingInvoice();

            // Eksempel
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
            //reservation.CustomerTypes = Mangler
            //reservation.Additions = Mangler
            // reservation.Spot = Mangler, vent til i morgen
            return reservation;
        }

        public Reservation MarkReservationAsSent(int orderNumber)
        {
            // Det samme gælder her, du retunere kun nået af reservations objektet
            return dal.MarkReservationAsSent(orderNumber);
        }
        #endregion
    }
}
