using System.Collections.Generic;

namespace ZAPBeachCampingLib.Core
{
    public class TentSpot : Spot
    {
        // Prices over tent spot
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

        public override string ToString()
        {
            return $"Telt nr. {Number} på almindelig plads ({prices["SPOT_FEE"].GetPrice()} DKK pr. døgn)";
        }
    }
}
