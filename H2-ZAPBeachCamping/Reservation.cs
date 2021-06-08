using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Reservation
    {
        #region Properties
        public Customer Customer { get; private set; }
        public Spot Spot { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int OrderNumber { get; private set; }
        public List<CustomerType> CustomerTypes { get; private set; }
        public bool IsInvoiceSent { get; internal set; }
        #endregion

        #region Constructors
        public Reservation(Customer customer, Spot spot, DateTime startDate, DateTime endDate, int orderNumber, List<CustomerType> customerTypes)
        {
            Customer = customer;
            Spot = spot;
            StartDate = startDate;
            EndDate = endDate;
            OrderNumber = orderNumber;
            CustomerTypes = customerTypes;
        }
        #endregion
    }
}
