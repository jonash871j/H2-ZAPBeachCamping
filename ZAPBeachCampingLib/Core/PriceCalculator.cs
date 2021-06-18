using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib.Core
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
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                switch (customerType)
                {
                    case CustomerType.Adult:
                        price += Reservation.Spot.Prices["ADULT_PRICE"].GetPrice();
                        break;
                    case CustomerType.Child:
                        price += Reservation.Spot.Prices["CHILD_PRICE"].GetPrice();
                        break;
                    case CustomerType.Dog:
                        price += Reservation.Spot.Prices["DOG_PRICE"].GetPrice();
                        break;
                }
            }
            return price;
        }
        public double GetTotalCampingSpotPrice()
        {
            if (Reservation.Spot.SpotType == SpotType.CampingSite)
            {
                CampingSpot campingSpot = (CampingSpot)Reservation.Spot;

                switch (campingSpot.CampingType)
                {
                    case CampingType.Small:
                        return campingSpot.Prices["SMALL_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    case CampingType.Large:
                        return campingSpot.Prices["LARGE_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    case CampingType.SeasonLarge:
                        break;
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
                return 50.0;
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
    }
}
