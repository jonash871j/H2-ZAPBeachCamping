using System;
using System.Collections.Generic;

namespace ZAPBeachCampingLib
{
    public static class SeasonCalculator
    {
        private static Dictionary<SeasonType, DateTime[]> seasonDatePeriods = new Dictionary<SeasonType, DateTime[]>()
        {
            { SeasonType.SeasonSpring, new DateTime[]{ new DateTime(1, 4, 1), new DateTime(1, 6, 30) } },
            { SeasonType.SeasonSummer, new DateTime[]{ new DateTime(1, 4, 1), new DateTime(1, 9, 30) } },
            { SeasonType.SeasonAutumn, new DateTime[]{ new DateTime(1, 8, 15), new DateTime(1, 10, 31) } },
            { SeasonType.SeasonWinter, new DateTime[]{ new DateTime(1, 10, 1), new DateTime(1, 3, 31) } },
        };
        private const int SEASON_START = 0;
        private const int SEASON_END = 1;

        public static bool IsHighSeason()
        {
            DateTime highSeasonStart = new DateTime(DateTime.Now.Year, 6, 14);
            DateTime highSeasonEnd = new DateTime(DateTime.Now.Year, 7, 15);

            if (DateTime.Now >= highSeasonStart && DateTime.Now <= highSeasonEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime GetSeasonStartDate(SeasonType seasonType)
        {
            DateTime seasonStart = seasonDatePeriods[seasonType][SEASON_START];
            seasonStart = seasonStart.AddYears(DateTime.Now.Year - 1);

            if (DateTime.Now > seasonStart)
            {
                return new DateTime(seasonStart.Year + 1, seasonStart.Month, seasonStart.Day);
            }
            else
            {
                return seasonStart;
            }
        }
        public static DateTime GetSeasonEndDate(SeasonType seasonType)
        {
            DateTime seasonStart = seasonDatePeriods[seasonType][SEASON_START];
            DateTime seasonEnd = seasonDatePeriods[seasonType][SEASON_END];
            seasonStart = seasonStart.AddYears(DateTime.Now.Year - 1);
            seasonEnd = seasonEnd.AddYears(DateTime.Now.Year - 1);

            if (DateTime.Now > seasonStart)
            {
                return new DateTime(seasonEnd.Year + 1, seasonEnd.Month, seasonEnd.Day);
            }
            else
            {
                return seasonEnd;
            }
        }
    }
}
