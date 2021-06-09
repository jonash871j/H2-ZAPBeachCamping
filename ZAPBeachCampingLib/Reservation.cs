using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        #region Properties
        public int OrderNumber { get; internal set; } = -1;
        public Customer Customer { get; private set; }
        public Spot Spot { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<CustomerType> CustomerTypes { get; private set; }
        public List<Addition> Additions { get; set; }
        public bool IsInvoiceSent { get; internal set; } = false;
        #endregion

        #region Constructors
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
