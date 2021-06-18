using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public abstract class Spot
    {
        #region Properties
        public string Number { get; private set; }
        public SpotType SpotType { get; private set; }
        public bool IsGoodView { get; set; }
        public Dictionary<string, Price> Prices { get; private set; }

        #endregion

        #region Constructors

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
        #endregion
    }
}
