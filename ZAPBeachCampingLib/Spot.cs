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
        public Spot(string number, SpotType spotType, bool isGoodView, Dictionary<string, Price> prices)
        {
            Number = number;
            SpotType = spotType;
            Prices = prices;
            IsGoodView = isGoodView;
        }
        #endregion
    }
}
