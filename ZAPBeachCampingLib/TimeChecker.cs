using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public static class TimeChecker
    {
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
    }
}
