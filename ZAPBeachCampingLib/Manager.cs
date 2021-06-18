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
        public event ErrorEventHandler Failure;

        public Manager()
        {
            dal.DataAccessFailure += OnFailure;
        }

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

        public List<CustomerType> GetCustomerTypes(int orderNumber)
        {

            return dal.GetCustomerType(orderNumber);
        }

        public void CreateCustomerTypes(int orderNumber, CustomerType value)
        {
            dal.CreateCustomerTypes(orderNumber, value);
        }
        #endregion

        #region Reservation
        public bool CreateReservation(Customer customer, ReservationPrefences reservationPrefences)
        {
            string errorMsg;
            if (!reservationPrefences.IsValidDates(out errorMsg) || !customer.IsValid(out errorMsg))
            {
                Failure.Invoke(errorMsg);
                return false;
            }

            List<Spot> spots = GetSpotsBySearch(
                reservationPrefences.GetStartDate(),
                reservationPrefences.GetEndDate(),
                reservationPrefences.SpotType,
                reservationPrefences.CampingType,
                reservationPrefences.HutType,
                false
            );
            if (spots.Count > 0)
            {
                Reservation reservation;
                dal.CreateReservation(reservation = new Reservation(
                    customer,
                    spots[0],
                    0.0,
                    reservationPrefences.GetStartDate(),
                    reservationPrefences.GetEndDate(),
                    reservationPrefences.GetCustomerTypes(),
                    new List<Addition>()
                ));

                double price = reservation.GetTotalPrice();
                return true;
            }
            else
            {
                Failure.Invoke("Der er desværre ikke flere ledige pladser udfra dine valg.");
                return false;
            }
        }
        public List<Reservation> GetAllReservationsWithMissingInvoice()
        {
            return GetFullReservations(dal.GetAllReservationsWithMissingInvoice());
        }

        public Reservation GetReservation(int orderNumber)
        {
            Reservation reservation = dal.GetReservation(orderNumber);
            reservation.Customer = GetCustomer(reservation.CustomerEmail);
            reservation.CustomerTypes = dal.GetCustomerType(reservation.OrderNumber);
            reservation.Additions = dal.GetReservationAdditions(orderNumber);
            reservation.Spot = dal.GetSpot(reservation.SpotNumber);
            
            return reservation;
        }

        public void MarkReservationAsSent(int orderNumber)
        {
            dal.MarkReservationAsSent(orderNumber);
        }
        #endregion
        public Spot GetSpot(string spotNumber)
        {
            return dal.GetSpot(spotNumber);
        }
        public List<Spot> GetSpotsBySearch(DateTime startDate, DateTime endDate, SpotType spotType, CampingType campingType, HutType hutType, bool isGoodView)
        {
            List<Spot> spots = dal.GetSpotsBySearch(spotType, campingType, hutType, isGoodView);

            foreach(string unavaibleSpotNumber in dal.GetAllUnavailbleSpotNumbersBetweenDate(startDate, endDate))
            {
                Spot spotToRemove = spots.SingleOrDefault(s => s.Number == unavaibleSpotNumber);
                if (spotToRemove != null)
                {
                    spots.Remove(spotToRemove);
                }
            }
            return spots;
        }

        private List<Reservation> GetFullReservations(List<Reservation> reservations) 
        {
            List<Reservation> fullReservations = new List<Reservation>();
            foreach (Reservation reservation in reservations)
            {
                fullReservations.Add(GetReservation(reservation.OrderNumber));
            }
            return fullReservations;
        }
        private void OnFailure(string message)
        {
            Failure.Invoke(message);
        }
    }
}
