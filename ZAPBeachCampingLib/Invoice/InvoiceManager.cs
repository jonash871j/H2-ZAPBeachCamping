using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using ZAPBeachCampingLib.Core;

namespace ZAPBeachCampingLib.Invoice
{
    public class InvoiceManager
    {
        private DataAccess dal;
        public MessageEventHandler Log;

        public InvoiceManager()
        {
            dal = new DataAccess();
        }

        /// <summary>
        /// Used to start a thread that constantly checks if any 
        /// reservations is missing an invoice and then send them one.
        /// </summary>
        public void StartInvoiceThread()
        {
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        List<Reservation> reservations = dal.GetAllReservationsWithMissingInvoice();

                        if (reservations != null && reservations.Count != 0)
                        {
                            Reservation reservation = reservations.FirstOrDefault();
                            reservation = dal.GetReservation(reservation.OrderNumber);
                            SendInvoice(reservation);
                            dal.MarkReservationAsSent(reservation.OrderNumber);
                        }
                        Thread.Sleep(1000);
                    }
                    catch (Exception exception)
                    {
                        Log?.Invoke($"<{DateTime.Now} : InvoiceThread> {exception.Message}");
                        Thread.Sleep(10000);
                    }
                }
            }).Start();
        }

        /// <summary>
        /// Used to send an invoice
        /// </summary>
        public void SendInvoice(Reservation reservation)
        {
            // Checks if invoice ignore settings is disabled
            if (bool.Parse(ConfigurationManager.AppSettings["InvoiceIgnore"]) == false)
            {
                EmailSender emailSender = new EmailSender(
                    ConfigurationManager.AppSettings["Email"],
                    ConfigurationManager.AppSettings["EmailPassword"]
                );
                InvoiceCreator invoiceCreator = new InvoiceCreator();

                // Creates invoice as a PDF file 
                string invoicePath = invoiceCreator.Create(reservation, ConfigurationManager.AppSettings["InvoicePath"], "Skabalon.docx");

                // Sends email with invoice to customer
                emailSender.SendEmailAttachement(
                    reservation.Customer.Email,
                    "ZAP Beach Camping faktura",
                    "Hej " + reservation.Customer.FirstName + "\n\nTusind tak for din bestilling, " +
                    "vi håber du får en uforglemmelig tur hos ZAP Beach Camping.\n\n\n" +
                    "Med venlig hilsen\n\nZAP Beach Camping",
                    invoicePath
                );
            }
        }
    }
}
