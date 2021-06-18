using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        #region Properties
        public int OrderNumber { get; internal set; } = -1;
        public Customer Customer { get; internal set; }
        internal string CustomerEmail { get; set; }
        public Spot Spot { get; internal set; }
        internal string SpotNumber { get; set; }
        public double TotalPrice { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public List<CustomerType> CustomerTypes { get; internal set; }
        public List<Addition> Additions { get; set; }
        public bool IsInvoiceSent { get; internal set; } = false;
        public bool IsPayingForCleaning { get; set; }
        #endregion

        #region Constructors

        internal Reservation()
        {

        }
        public Reservation(Customer customer, Spot spot, double totalPrice, DateTime startDate, DateTime endDate, List<CustomerType> customerTypes, List<Addition> additions)
        {
            Customer = customer;
            Spot = spot;
            TotalPrice = totalPrice;
            StartDate = startDate;
            EndDate = endDate;
            CustomerTypes = customerTypes;
            Additions = additions;
        }
        #endregion

        public double GetTotalPrice()
        {
            double price = 0.0;

            price += GetTotalTravelersPrice();
            price += GetTotalCampingSpotPrice();
            price += GetTotalTentSpotPrice();
            price += GetTotalHutSpotPrice();
            price += GetGoodViewPrice();
            price += GetHutSpotCleaningPrice();

            return price;
        }
        public double GetTotalTravelersPrice()
        {
            double price = 0.0;
            foreach (CustomerType customerType in CustomerTypes)
            {
                switch (customerType)
                {
                    case CustomerType.Adult:
                        price += Spot.Prices["ADULT_PRICE"].GetPrice();
                        break;
                    case CustomerType.Child:
                        price += Spot.Prices["CHILD_PRICE"].GetPrice();
                        break;
                    case CustomerType.Dog:
                        price += Spot.Prices["DOG_PRICE"].GetPrice();
                        break;
                }
            }
            return price;
        }
        public double GetTotalCampingSpotPrice()
        {
            if (Spot.SpotType == SpotType.CampingSite)
            {
                CampingSpot campingSpot = (CampingSpot)Spot;

                switch (campingSpot.CampingType)
                {
                    case CampingType.Small:
                        return campingSpot.Prices["SMALL_SPOT_FEE"].GetPrice() * GetTravelPeriodInDays();
                    case CampingType.Large:
                        return campingSpot.Prices["LARGE_SPOT_FEE"].GetPrice() * GetTravelPeriodInDays();
                    case CampingType.SeasonLarge:
                        break;
                }
            }
            return 0.0;
        }
        public double GetTotalHutSpotPrice()
        {
            if (Spot.SpotType == SpotType.HutSite)
            {
                HutSpot hutSpot = (HutSpot)Spot;

                switch (hutSpot.HutType)
                {
                    case HutType.Default:
                        return hutSpot.Prices["DEFAULT_PRICE"].GetPrice() * GetTravelPeriodInDays();
                    case HutType.Luxury:
                        return hutSpot.Prices["LUXURY_PRICE"].GetPrice() * GetTravelPeriodInDays();
                }
            }
            return 0.0;
        }
        public double GetTotalTentSpotPrice()
        {
            if (Spot.SpotType == SpotType.TentSite)
            {
                return ((TentSpot)Spot).Prices["SPOT_FEE"].GetPrice() * GetTravelPeriodInDays();
            }
            return 0.0;
        }
        public double GetGoodViewPrice()
        {
            if (Spot.IsGoodView)
            {
                return 50.0;
            }
            return 0.0;
        }
        public double GetHutSpotCleaningPrice()
        {
            if (Spot.SpotType == SpotType.HutSite && IsPayingForCleaning)
            {
                return 150.0;
            }
            return 0.0;
        }
        public int GetTravelPeriodInDays()
        {
            return (int)(EndDate - StartDate).TotalDays;
        }
    }
}
