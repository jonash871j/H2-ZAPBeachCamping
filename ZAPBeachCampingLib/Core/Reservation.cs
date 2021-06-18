using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        internal string CustomerEmail { get; set; } // FOREIGN KEY
        internal string SpotNumber { get; set; } // FOREIGN KEY

        public int OrderNumber { get; private set; } = -1; 
        public Customer Customer { get; internal set; }
        public Spot Spot { get; internal set; }
        public List<CustomerType> CustomerTypes { get; internal set; }
        public List<Addition> Additions { get; internal set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsInvoiceSent { get; private set; } = false;
        public bool IsPayForCleaning { get; private set; } = false;

        internal Reservation() { }
        public Reservation(Customer customer, Spot spot, DateTime startDate, DateTime endDate, List<CustomerType> customerTypes, List<Addition> additions, bool isPayForCleaning)
        {
            Customer = customer;
            Spot = spot;
            StartDate = startDate;
            EndDate = endDate;
            CustomerTypes = customerTypes;
            Additions = additions;
            IsPayForCleaning = isPayForCleaning;
        }

        public int GetTravelPeriodInDays()
        {
            return (int)(EndDate - StartDate).TotalDays;
        }
    }
}
