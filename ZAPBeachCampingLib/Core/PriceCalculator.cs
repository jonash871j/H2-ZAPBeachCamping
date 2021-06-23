using System;

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
            price += GetCampingSpotDiscountPrice();
            return price;
        }
        public double GetTotalCampingSpotPrice()
        {
            //Checks if spotType is campingSite
            if (Reservation.Spot.SpotType == SpotType.CampingSite)
            {
                CampingSpot campingSpot = (CampingSpot)Reservation.Spot;

                //Checks if reservation seansonType 
                if (Reservation.SeasonType == SeasonType.None)
                {
                    switch (campingSpot.CampingType)
                    {
                        //Returns price of a small camping type and period of days
                        case CampingType.Small:
                            return campingSpot.Prices["SMALL_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                        //Returns price of a large camping type and period of days
                        case CampingType.Large:
                            return campingSpot.Prices["BIG_SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    }
                }
                else
                {   
                    switch (Reservation.SeasonType)
                    {
                        //Return camping spot price for seasontype
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
            //Checks if spotType is HuTSite
            if (Reservation.Spot.SpotType == SpotType.HutSite)
            {
                HutSpot hutSpot = (HutSpot)Reservation.Spot;

                switch (hutSpot.HutType)
                {
                    //Returns price of a default hutspot and period of days
                    case HutType.Default:
                        return hutSpot.Prices["DEFAULT_PRICE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                    //Returns price of a luxury hutspot and period of days
                    case HutType.Luxury:
                        return hutSpot.Prices["LUXURY_PRICE"].GetPrice() * Reservation.GetTravelPeriodInDays();
                }
            }
            return 0.0;
        }
        public double GetTotalTentSpotPrice()
        {
            //Checks if spotType is tentsite
            if (Reservation.Spot.SpotType == SpotType.TentSite)
            {
                //Returns price of a tent spot and period of days
                return ((TentSpot)Reservation.Spot).Prices["SPOT_FEE"].GetPrice() * Reservation.GetTravelPeriodInDays();
            }
            return 0.0;
        }
        public double GetGoodViewPrice()
        {
            //Checks if reservation has IsGoodView
            if (Reservation.Spot.IsGoodView)
            {
                //Returns price for IsGoodView by period of days
                return 75.0 * Reservation.GetTravelPeriodInDays();
            }
            return 0.0;
        }
        public double GetHutSpotCleaningPrice()
        {
            //Checks if reservation spottype is hutSite and has IsPayforCleaning
            if (Reservation.Spot.SpotType == SpotType.HutSite && Reservation.IsPayForCleaning)
            {
                //Return price of IsPayForCleaning
                return 150.0;
            }
            return 0.0;
        }
        public double GetTotalAdultPrice()
        {
            double price = 0.0;
            //Loop through reservation customerTypes
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                //Check if customerType is adult
                if (customerType == CustomerType.Adult)
                {
                    //Returns the price of an adult
                    price += Reservation.Spot.Prices["ADULT_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalChildPrice()
        {
            double price = 0.0;
            //Loop through reservation customerTypes
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                //Check if customerType is child
                if (customerType == CustomerType.Child)
                {
                    //Returns the price of an child
                    price += Reservation.Spot.Prices["CHILD_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalDogPrice()
        {
            double price = 0.0;
            //Loop through reservation customerTypes
            foreach (CustomerType customerType in Reservation.CustomerTypes)
            {
                //Check if customerType is child
                if (customerType == CustomerType.Dog)
                {
                    //Returns the price of an dog
                    price += Reservation.Spot.Prices["DOG_PRICE"].GetPrice();
                }
            }
            return price;
        }
        public double GetTotalAdditionsPrice()
        {
            double price = 0.0;
            //Loops through reservation additions
            foreach (Addition addition in Reservation.Additions)
            {
                //Checks if addition is IsDailyPayment
                if (addition.IsDailyPayment)
                {
                    //returns addition price of travel period
                    price += addition.Price * Reservation.GetTravelPeriodInDays();
                }
                else
                {
                    //returns addition price
                    price += addition.Price;
                }
            }
            return price;
        }
        public double GetCampingSpotDiscountPrice()
        {
            //Checks reservation spotType is campingSite and reservation seasonType is none
            if (Reservation.Spot.SpotType == SpotType.CampingSite && Reservation.SeasonType == SeasonType.None)
            {
                CampingSpot campingSpot = (CampingSpot)Reservation.Spot;

                switch (campingSpot.CampingType)
                {
                    //Return price of a small campingspot with a travel period over 3 days
                    case CampingType.Small:
                        return -campingSpot.Prices["SMALL_SPOT_FEE"].GetPrice() * Math.Floor(Reservation.GetTravelPeriodInDays() / 3.0);
                    //Return price of a large campingspot with a travel period over 3 days
                    case CampingType.Large:
                        return -campingSpot.Prices["BIG_SPOT_FEE"].GetPrice() * Math.Floor(Reservation.GetTravelPeriodInDays() / 3.0);
                }
            }
            return 0.0;
        }
    }
}
