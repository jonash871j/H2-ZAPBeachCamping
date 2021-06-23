using System;
using System.Collections.Generic;

namespace ZAPBeachCampingLib.Core
{
    public static class SeasonCalculator
    {
        // Dictionary over each season type and
        // the start date and end date
        private static Dictionary<SeasonType, DateTime[]> seasonDatePeriods = new Dictionary<SeasonType, DateTime[]>()
        {
            { SeasonType.SeasonSpring, new DateTime[]{ new DateTime(1, 4, 1), new DateTime(1, 6, 30) } },
            { SeasonType.SeasonSummer, new DateTime[]{ new DateTime(1, 4, 1), new DateTime(1, 9, 30) } },
            { SeasonType.SeasonAutumn, new DateTime[]{ new DateTime(1, 8, 15), new DateTime(1, 10, 31) } },
            { SeasonType.SeasonWinter, new DateTime[]{ new DateTime(1, 10, 1), new DateTime(1, 3, 31) } },
        };
        private const int SEASON_START = 0;
        private const int SEASON_END = 1;

        /// <summary>
        /// Used to check if high season or low season
        /// </summary>
        /// <returns>true if high season else low season</returns>
        public static bool IsHighSeason()
        {
            DateTime highSeasonStart = new DateTime(DateTime.Now.Year, 6, 14);
            DateTime highSeasonEnd = new DateTime(DateTime.Now.Year, 7, 15);

            return DateTime.Now >= highSeasonStart && DateTime.Now <= highSeasonEnd;
        }

        /// <summary>
        /// Used to get lates possible season start date 
        /// based on SeasonType
        /// </summary>
        public static DateTime GetSeasonStartDate(SeasonType seasonType)
        {
            // Gets date time with month and date based on season type
            DateTime seasonStart = seasonDatePeriods[seasonType][SEASON_START];

            // Set year of season start to current year
            seasonStart = seasonStart.AddYears(DateTime.Now.Year - 1);

            if (DateTime.Now > seasonStart)
            {
                // If it's to late then the first valid season is next year.
                return new DateTime(seasonStart.Year + 1, seasonStart.Month, seasonStart.Day);
            }
            else
            {
                return seasonStart;
            }
        }

        /// <summary>
        /// Used to get lates possible season end date 
        /// based on SeasonType
        /// </summary>
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
