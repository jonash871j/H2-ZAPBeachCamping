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
            Reservation reservation = new Reservation(
                new Customer(" ", " ", " ", " ", " ", " "),
                manager.GetSpot("2"),
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(4),
                new List<CustomerType>(),
                new List<Addition>(),
                true
                );



            //manager.CreateReservation(new Customer(" ", " ", " ", " ", " ", " "),
            //    new BookingOptions()
            //    {
            //        StartDate = DateTime.Now.AddDays(1).ToShortDateString(),
            //        EndDate = DateTime.Now.AddDays(2).ToShortDateString(),
            //        SpotType = SpotType.CampingSite,
            //        HutType = HutType.Luxury
            //    });

            //for (int i = 0; i < 60; i++)
            //{

            //    if (i % 3 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}



            PriceCalculator priceCalculator = new PriceCalculator(reservation);
            Console.WriteLine("Hello");
            Console.WriteLine(priceCalculator.GetTotalCampingSpotPrice());
            Console.WriteLine(priceCalculator.GetCampingSpotDiscountPrice());


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
