using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class CampingSpot : Spot
    {
        private static Dictionary<string, Price> prices = new Dictionary<string, Price>()
        {
            {"SMALL_SPOT_FEE", new Price(60, 50) },
            {"BIG_SPOT_FEE", new Price(80, 65) },
            {"ADULT_PRICE", new Price(82, 87) },
            {"CHILD_PRICE", new Price(42, 49) },
            {"DOG_PRICE", new Price(30, 30) },
            {"SPRING_PRICE", new Price(4100, 4100)},
            {"SUMMER_PRICE", new Price(9300, 9300)},
            {"AUTUMN_PRICE", new Price(2900, 2900)},
            {"VINTER_PRICE", new Price(3500, 3500)},
        };

        public CampingType CampingType { get; set; }

        internal CampingSpot()
            : base(SpotType.CampingSite, prices)
        {

        }
    }
}
