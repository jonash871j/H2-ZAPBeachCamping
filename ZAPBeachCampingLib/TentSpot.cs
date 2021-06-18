using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class TentSpot : Spot
    {
        private static Dictionary<string, Price> prices = new Dictionary<string, Price>()
        {
            {"ADULT_PRICE" , new Price(82, 87) },
            {"CHILD_PRICE" , new Price(42, 49) },
            {"DOG_PRICE" , new Price(0, 0) },
            {"SPOT_FEE", new Price(35, 45) },
        };

        internal TentSpot()
            : base(SpotType.TentSite, prices)
        {
        }

        public TentSpot(string number, bool isGoodView) 
            : base(number, SpotType.TentSite, isGoodView, prices)
        {

        }

    }
}
