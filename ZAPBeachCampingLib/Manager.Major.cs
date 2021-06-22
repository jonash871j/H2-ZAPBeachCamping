using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;

namespace ZAPBeachCampingLib
{
    public partial class Manager
    {
        /// <summary>
        /// Used to start a thread that constantly checks if any 
        /// reservations is missing an invoice and then send them one.
        /// </summary>
        public static void StartInvoiceThread()
        {
            new Thread(() =>
            {
                try
                {
                    Manager manager = new Manager();

                    while (true)
                    {
                        List<Reservation> reservations = manager.GetAllReservationsWithMissingInvoice();

                        if (reservations != null && reservations.Count != 0)
                        {
                            Reservation reservation = reservations.FirstOrDefault();
                            reservation = manager.GetReservation(reservation.OrderNumber);
                            manager.SendInvoice(reservation);
                            manager.MarkReservationAsSent(reservation.OrderNumber);
                        }

                        Thread.Sleep(1000);
                    }
                }
                catch(Exception exception)
                {
                    File.AppendAllText(
                        ConfigurationManager.AppSettings["InvoicePath"] + "InvoiceThread-ErrorLog.log", 
                        $"<{DateTime.Now}> {exception.Message}\n"
                    );
                    Thread.Sleep(10000);
                }
            }).Start();
        }

        /// <summary>
        /// Used to send an invoice
        /// </summary>
        public void SendInvoice(Reservation reservation)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["InvoiceIgnore"]) == false)
            {
                InvoiceCreator invoiceCreator = new InvoiceCreator(
                    new EmailSender("ZAPBeachCamping@gmail.com", "Passw0rd!123")
                );
                invoiceCreator.OpenWord();
                invoiceCreator.Send(reservation, ConfigurationManager.AppSettings["InvoicePath"], "Skabalon.docx");
                invoiceCreator.CloseWord();
            }
        }

        /// <summary>
        /// Used to make a seach on spots
        /// </summary>
        /// <returns>All available spots based on search</returns>
        public List<Spot> GetSpotsBySearch(DateTime startDate, DateTime endDate, SpotType spotType, CampingType campingType, HutType hutType, bool isGoodView)
        {
            List<Spot> spots = dal.GetSpotsBySearch(spotType, campingType, hutType, isGoodView);

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

            if (bookingOptions.SeasonType == SeasonType.None)
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
            else
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
}