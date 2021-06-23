using System;
using System.Collections.Generic;
using System.Linq;

namespace ZAPBeachCampingLib.Core
{
    public partial class CampingManager
    {
        /// <summary>
        /// Used to create a new reservation
        /// </summary>
        /// <returns>True if successfull</returns>
        public bool CreateReservation(Customer customer, BookingOptions bookingOptions)
        {
            // Error checking
            string errorMsg;
            if (!bookingOptions.IsValidDates(out errorMsg) || !customer.IsValid(out errorMsg))
            {
                MissingInformation?.Invoke(errorMsg);
                return false;
            }

            // Creates reservation
            if (bookingOptions.SeasonType == SeasonType.None)
            {
                return CreateDefaultReservation(customer, bookingOptions);
            }
            else
            {
                return CreateSeasonReservation(customer, bookingOptions);
            }
        }

        /// <summary>
        /// Used to create a default reservation
        /// </summary>
        /// <returns>true if successful</returns>
        private bool CreateDefaultReservation(Customer customer, BookingOptions bookingOptions)
        {
            // Makes a seach to get all avaible spots
            List<Spot> spots = GetSpotsBySearch(
                bookingOptions.GetStartDate(),
                bookingOptions.GetEndDate(),
                bookingOptions.SpotType,
                bookingOptions.CampingType,
                bookingOptions.HutType,
                bookingOptions.IsGoodView
            );

            if (spots.Count > 0)
            {
                // Adds the reservation to the database
                dal.CreateReservation(new Reservation(
                    customer,
                    spots[0],
                    bookingOptions.GetStartDate(),
                    bookingOptions.GetEndDate(),
                    bookingOptions.GetCustomerTypes(),
                    bookingOptions.Additions,
                    bookingOptions.IsPayingForCleaning
                ));

                return true;
            }
            else
            {
                MissingInformation?.Invoke("Der er desværre ikke flere ledige pladser udfra dine valg.");
                return false;
            }
        }

        /// <summary>
        /// Used to create season reservation
        /// </summary>
        /// <returns>true if succrssful</returns>
        private bool CreateSeasonReservation(Customer customer, BookingOptions bookingOptions)
        {
            // Makes a seach to get all avaible spots
            List<Spot> spots = GetSpotsBySearch(
                bookingOptions.GetStartDate(),
                bookingOptions.GetEndDate(),
                SpotType.CampingSite,
                CampingType.Large,
                HutType.None,
                isGoodView: false
            );

            if (spots.Count > 0)
            {
                // Adds the reservation to the database
                dal.CreateReservation(new Reservation(
                    customer,
                    spots[0],
                    bookingOptions.GetStartDate(),
                    bookingOptions.GetEndDate(),
                    new List<CustomerType>(),
                    bookingOptions.Additions,
                    seasonType: bookingOptions.SeasonType
                ));

                return true;
            }
            else
            {
                MissingInformation?.Invoke("Der er desværre ikke flere ledige pladser udfra dine valg.");
                return false;
            }
        }
    }
}