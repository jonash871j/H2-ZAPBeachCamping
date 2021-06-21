using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public class PriceCalculator
    {
        public Reservation Reservation { get; private set; }

        public PriceCalculator(Reservation reservation)
        {
            Reservation = reservation;
        }

        public double GetTotalPrice()
        {
            double price = 0.0;

            price += GetTotalSpotPrice();
            price += GetGoodViewPrice();
            price += GetHutSpotCleaningPrice();
            price += GetTotalAdditionsPrice();

            return price;
        }
        public double GetTotalTravelersPrice()
        {
            double price = 0.0;
            price += GetTotalAdultPrice();
            price += GetTotalChildPrice();
            price += GetTotalDogPrice();
            return price;
        }
        public double GetTotalSpotPrice()
        {
            double price = 0.0;

            price += GetTotalHutSpotPrice();
            price += GetTotalCampingSpotPrice();
            price += GetTotalTentSpotPrice();

            return price;
        }
        public double GetTotalCampingSpotPrice()
        {
            if (Reservation.Spot.SpotType == SpotType.CampingSite)
            {
                CampingSpot campingSpot = (CampingSpot)Reservation.Spot;

                if (Reservation.SeasonType == SeasonType.None)
                {
                    switch (campingSpot.CampingType)
                    {
                        case CampingType.Small:
                            return campingSpot.Prices["SMALL_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                        case CampingType.Large:
                            return campingSpot.Prices["BIG_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    }
                }
                else
                {
                    switch (Reservation.SeasonType)
                    {
                        case SeasonType.SeasonSpring:
                            return campingSpot.Prices["SPRING_PRICE"].GetPrice();
                        case SeasonType.SeasonSummer:
                            return campingSpot.Prices["SUMMER_PRICE"].GetPrice();
                        case SeasonType.SeasonAutumn:
                            return campingSpot.Prices["AUTUMN_PRICE"].GetPrice();
                        case SeasonType.SeasonWinter:
                            return campingSpot.Prices["VINTER_PRICE"].GetPrice();
                    }
                }
            }
            return 0.0;
        }
        public double GetTotalHutSpotPrice()
        {
            if (Reservation.Spot.SpotType == SpotType.HutSite)
            {
                HutSpot hutSpot = (HutSpot)Reservation.Spot;

                switch (hutSpot.HutType)
                {
                    case HutType.Default:
                        return hutSpot.Prices["DEFAULT_PRICE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    case HutType.Luxury:
                        return hutSpot.Prices["LUXURY_PRICE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                }
            }
            return 0.0;
        }
        public double GetTotalTentSpotPrice()
        {
            if (Reservation.Spot.SpotType == SpotType.TentSite)
            {
                return ((TentSpot)Reservation.Spot).Prices["SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
            }
            return 0.0;
        }
        public double GetGoodViewPrice()
        {
            if (Reservation.Spot.IsGoodView)
            {
                return 75.0 * Reservation.GetTravelPeriodInDays();
            }
            return 0.0;
        }
        public double GetHutSpotCleaningPrice()
        {
            if (Reservation.Spot.SpotType == SpotType.HutSite && Reservation.IsPayForCleaning)
            {
                return 150.0;
            }
            return 0.0;
        }
        public double GetTotalAdultPrice()
        {
            double price = 0.0;
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                if (customerType == CustomerType.Adult)
                {
                    price += Reservation.Spot.Prices["ADULT_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalChildPrice()
        {
            double price = 0.0;
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                if (customerType == CustomerType.Child)
                {
                    price += Reservation.Spot.Prices["CHILD_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalDogPrice()
        {
            double price = 0.0;
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                if (customerType == CustomerType.Dog)
                {
                    price += Reservation.Spot.Prices["DOG_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalAdditionsPrice()
        {
            double price = 0.0;

            foreach (Addition addition in Reservation.Additions)
            {
                if (addition.IsDailyPayment)
                {
                    price += addition.Price * Reservation.GetTravelPeriodInDays();
                }
                else
                {
                    price += addition.Price;
                }
            }

            return price;
        }
    }
}
