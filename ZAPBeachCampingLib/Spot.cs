using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public abstract class Spot
    {
        #region Properties
        public int Number { get; private set; }
        public SpotType SpotType { get; private set; }
        public List<Addition> Additions { get; private set; }
        public Dictionary<string, Price> Prices { get; private set; }

        #endregion

        #region Constructors
        public Spot(int number, SpotType spotType, List<Addition> additions, Dictionary<string, Price> prices)
        {
            Number = number;
            SpotType = spotType;
            Additions = additions;
            Prices = prices;
        }
        #endregion
    }
}
