using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public class ReservationPrefences
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public SpotType SpotType { get; set; }
        public CampingType CampingType { get; set; }
        public HutType HutType { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Dog { get; set; }

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
            errorMsg = "";
            return true;
        }

        public DateTime GetStartDate()
        {
            return Convert.ToDateTime(StartDate);
        }
        public DateTime GetEndDate()
        {
            return Convert.ToDateTime(EndDate);
        }
    }
}
