using System.Collections.Generic;

namespace ZAPBeachCampingLib.Core
{
    public abstract class Spot
    {
        public string Number { get; private set; }
        public SpotType SpotType { get; private set; }
        public bool IsGoodView { get; set; } = false;
        public Dictionary<string, Price> Prices { get; private set; }

        internal Spot()
        {

        }
        internal Spot(SpotType spotType, Dictionary<string, Price> prices)
        {
            SpotType = spotType;
            Prices = prices;
        }
        public Spot(string number, SpotType spotType, bool isGoodView, Dictionary<string, Price> prices)
            : this(spotType, prices)
        {
            Number = number;
            IsGoodView = isGoodView;
        }
    }
}
