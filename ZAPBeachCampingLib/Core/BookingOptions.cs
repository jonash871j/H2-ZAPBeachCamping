﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZAPBeachCampingLib
{
    public class BookingOptions
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public SpotType SpotType { get; set; }
        public CampingType CampingType { get; set; }
        public SeasonType SeasonType { get; set; }
        public HutType HutType { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Dog { get; set; }
        public bool IsGoodView { get; set; }
        public bool IsPayingForCleaning { get; set; }
        public List<Addition> Additions { get; set; }

        public List<CustomerType> GetCustomerTypes()
        {
            List<CustomerType> customerTypes = new List<CustomerType>();

            void AddCustomerTypes(int amount, CustomerType customerType)
            {
                for (int i = 0; i < amount; i++)
                {
                    customerTypes.Add(customerType);
                }
            }

            AddCustomerTypes(Adult, CustomerType.Adult);
            AddCustomerTypes(Child, CustomerType.Child);
            AddCustomerTypes(Dog, CustomerType.Dog);

            return customerTypes;
        }

        public bool IsValidDates(out string errorMsg)
        {
            if (SeasonType == SeasonType.None)
            {
                if (GetStartDate().Date < DateTime.Now.Date)
                {
                    errorMsg = "Start dato manlger.";
                    return false;
                }
                if (GetEndDate().Date < GetStartDate().Date)
                {
                    errorMsg = "Slut dato manlger.";
                    return false;
                }
            }
            errorMsg = "";
            return true;
        }

        public DateTime GetStartDate()
        {
            if (SeasonType == SeasonType.None)
            {
                return Convert.ToDateTime(StartDate);
            }
            else
            {
                return SeasonCalculator.GetSeasonStartDate(SeasonType);
            }
        }
        public DateTime GetEndDate()
        {
            if (SeasonType == SeasonType.None)
            {
                return Convert.ToDateTime(EndDate);
            }
            else
            {
                return SeasonCalculator.GetSeasonEndDate(SeasonType);
            }
        }
    }
}
