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

            //foreach (Reservation reservation in manager.GetAllReservationsWithMissingInvoice())
            //{
            //    Console.WriteLine(reservation.OrderNumber);
            //}

            Console.WriteLine(manager.GetReservations(2).Customer.FirstName);

            Console.WriteLine(manager.GetCustomer("Test@gmail.com").FirstName);

        }
    }
}
