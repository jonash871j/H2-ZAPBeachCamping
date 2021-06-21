using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        internal string CustomerEmail { get; set; } // FOREIGN KEY
        internal string SpotNumber { get; set; } // FOREIGN KEY

        public int OrderNumber { get; internal set; } = -1; 
        public Customer Customer { get; internal set; }
        public Spot Spot { get; internal set; }
        public List<CustomerType> CustomerTypes { get; internal set; }
        public List<Addition> Additions { get; internal set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsInvoiceSent { get; private set; } = false;
        public bool IsPayForCleaning { get; private set; }
        public SeasonType SeasonType { get; private set; }

        internal Reservation() { }
        public Reservation(Customer customer,
                           Spot spot,
                           DateTime startDate,
                           DateTime endDate,
                           List<CustomerType> customerTypes,
                           List<Addition> additions,
                           bool isPayForCleaning = false,
                           SeasonType seasonType = SeasonType.None)
        {
            Customer = customer;
            Spot = spot;
            StartDate = startDate;
            EndDate = endDate;
            CustomerTypes = customerTypes;
            Additions = additions;
            IsPayForCleaning = isPayForCleaning;
            SeasonType = seasonType;
        }

        public int GetTravelPeriodInDays()
        {
            return (int)(EndDate - StartDate).TotalDays;
        }

        public string GetSpotDescription()
        {
            if (SeasonType == SeasonType.None)
            {
                return Spot.ToString();
            }
            else
            {
                switch (SeasonType)
                {
                    case SeasonType.SeasonSpring:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i forår sæson";
                    case SeasonType.SeasonSummer:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i sommer sæson";
                    case SeasonType.SeasonAutumn:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i efterår sæson";
                    case SeasonType.SeasonWinter:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i vinter sæson";
                    default:
                        return "";
                }
            }
        }
    }
}
