using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib.Core
{
    public class Price
    {
        public double HighSeason { get; private set; }
        public double LowSeason { get; private set; }

        public Price(double highSeason, double lowSeason)
        {
            HighSeason = highSeason;
            LowSeason = lowSeason;
        }

        /// <summary>
        /// Used to get the right price based on the season
        /// </summary>
        public double GetPrice()
        {
            if (SeasonCalculator.IsHighSeason())
            {
                return HighSeason;
            }
            else
            {
                return LowSeason;
            }
        }
    }
}
