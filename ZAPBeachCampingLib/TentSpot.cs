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
            {"SPOT_FEE", new Price(35, 45) },
        };

        public TentSpot(int number, List<Addition> additions) 
            : base(number, SpotType.TentSite, additions, prices)
        {

        }

    }
}
