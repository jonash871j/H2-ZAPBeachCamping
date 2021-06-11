using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        #region Properties
        public int OrderNumber { get; internal set; } = -1;
        public Customer Customer { get; internal set; }
        internal string CustomerEmail { get; set; }
        public Spot Spot { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public List<CustomerType> CustomerTypes { get; internal set; }
        public List<Addition> Additions { get; set; }
        public bool IsInvoiceSent { get; internal set; } = false;
        #endregion

        #region Constructors

        internal Reservation()
        {

        }
        public Reservation(Customer customer, Spot spot, DateTime startDate, DateTime endDate, List<CustomerType> customerTypes, List<Addition> additions)
        {
            Customer = customer;
            Spot = spot;
            StartDate = startDate;
            EndDate = endDate;
            CustomerTypes = customerTypes;
            Additions = additions;
        }
        #endregion
    }
}
