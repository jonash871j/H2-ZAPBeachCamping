using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPBeachCampingLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.CreateReservation(new Customer(" "," "," "," "," "," "), 
                new BookingOptions() 
                { 
                    StartDate = DateTime.Now.AddDays(1).ToShortDateString(), 
                    EndDate = DateTime.Now.AddDays(2).ToShortDateString(),
                    SpotType = SpotType.HutSite,
                    HutType = HutType.Luxury
                });

            //foreach (Reservation reservation in manager.GetAllReservationsWithMissingInvoice())
            //{
            //    Console.WriteLine($"OrderNumber: {reservation.OrderNumber}");
            //    Console.WriteLine($"CustomerEmail: {reservation.Customer.Email}");
            //    //Console.WriteLine($"SpotNumber: {reservation.Spot.Number}");
            //    Console.WriteLine($"Total Price: {reservation.TotalPrice}");
            //    Console.WriteLine($"StartDate: {reservation.StartDate}");
            //    Console.WriteLine($"EndDate: {reservation.EndDate}");
            //    Console.WriteLine($"IsInvoiceSent: {reservation.IsInvoiceSent}");
            //    Console.WriteLine();
            //}


            //foreach (Addition addition in manager.GetAllAddtion())
            //{
            //    Console.WriteLine($"{addition.Name} {addition.Price}");
            //}

            //Console.WriteLine(manager.GetReservations(2).Customer.FirstName);


            //Console.WriteLine(manager.GetReservations(2).Customer.FirstName);

            //Console.WriteLine(manager.GetCustomer("Test@gmail.com").FirstName);

            //Console.WriteLine(manager.MarkReservationAsSent(11));

            //manager.CreateCustomerTypes(10, CustomerType.Adult);

            //Reservation r = manager.GetReservation(10);

            //Console.WriteLine(r.Customer.FirstName);

            //foreach (CustomerType item in r.CustomerTypes)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (Addition item in r.Additions)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //Console.WriteLine(r.Spot.Number);
        }
    }
}
