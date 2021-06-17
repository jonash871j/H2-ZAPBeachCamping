using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAPBeachCampingLib
{
    public class ReservationPrefences
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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
                for (int i = 0; i < Adult; i++)
                {
                    customerTypes.Add(CustomerType.Adult);
                }
            }

            AddCustomerTypes(Adult, CustomerType.Adult);
            AddCustomerTypes(Child, CustomerType.Child);
            AddCustomerTypes(Dog, CustomerType.Dog);

            return customerTypes;
        }
    }
}
