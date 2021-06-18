using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class HutSpot : Spot
    {
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
        public HutSpot(string number, bool isGoodView, HutType hutType) 
            : base(number, SpotType.HutSite, isGoodView, prices)
        {
            HutType = hutType;
        }
    }
}
