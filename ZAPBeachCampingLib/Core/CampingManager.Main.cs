using System;
using System.Collections.Generic;
using System.Linq;

namespace ZAPBeachCampingLib.Core
{
    public partial class CampingManager
    {
        private DataAccess dal;
        public event MessageEventHandler MissingInformation;

        public CampingManager()
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

        /// <summary>
        /// Used to make a seach on spots
        /// </summary>
        /// <returns>all available spots based on search</returns>
        public List<Spot> GetSpotsBySearch(DateTime startDate, DateTime endDate, SpotType spotType, CampingType campingType, HutType hutType, bool isGoodView)
        {
            // Get every spot based on search
            List<Spot> spots = dal.GetSpotsBySearch(spotType, campingType, hutType, isGoodView);

            // Removes all unavailble spots based on date
            foreach (string unavaibleSpotNumber in dal.GetAllUnavailbleSpotNumbersBetweenDate(startDate, endDate))
            {
                Spot spotToRemove = spots.SingleOrDefault(s => s.Number == unavaibleSpotNumber);
                if (spotToRemove != null)
                {
                    spots.Remove(spotToRemove);
                }
            }
            return spots;
        }
    }
}
