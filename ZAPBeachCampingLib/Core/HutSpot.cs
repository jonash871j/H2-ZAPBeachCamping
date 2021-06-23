using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib.Core
{
    public class HutSpot : Spot
    {
        // Prices over hut spot
        private static Dictionary<string, Price> prices = new Dictionary<string, Price>()
        {
            {"DEFAULT_PRICE", new Price(500, 350) },
            {"LUXURY_PRICE", new Price(850, 600) },
            {"ADULT_PRICE" , new Price(82, 87) },
            {"CHILD_PRICE" , new Price(42, 49) },
            {"DOG_PRICE", new Price(30, 30) },
        };
        public HutType HutType{ get; private set; }

        internal HutSpot()
              : base(SpotType.HutSite, prices)
        {
        }

        public override string ToString()
        {
            switch (HutType)
            {
                case HutType.Default:
                    return $"Almindelig hytte nr. {Number} ({prices["DEFAULT_PRICE"].GetPrice()} DKK pr. døgn)";
                case HutType.Luxury:
                    return $"Luksus hytte nr. {Number} ({prices["LUXURY_PRICE"].GetPrice()} DKK pr. døgn)";
            }
            return "";
        }
    }
}
