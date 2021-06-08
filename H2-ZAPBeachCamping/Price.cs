using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Price
    {
        #region Properties

        public double HighSeason { get; private set; }
        public double LowSeason { get; private set; }
        #endregion

        #region Constructors
        public Price(double highSeason, double lowSeason)
        {
            HighSeason = highSeason;
            LowSeason = lowSeason;
        }
        #endregion

        #region Methods

        public double GetPrice()
        {
            if (TimeChecker.IsHighSeason())
            {
                return HighSeason;
            }
            else
            {
                return LowSeason;
            }
        }
        #endregion
    }
}
