using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
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
