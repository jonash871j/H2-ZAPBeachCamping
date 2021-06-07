using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{ 
    public enum SpotType
    {
        TentSite = 1,
        CampingSite = 2,
        HutSite = 3,
    };

    public enum HutType
    {
        Default = 1,
        Luxury = 2,
    }
    public enum CampingType
    {
        Small = 1,
        Large = 2,
        SeasonLarge = 3
    }
    public enum CustomerType
    {
        Adult = 1,
        Child = 2,
        Dog = 3,
    }
}
