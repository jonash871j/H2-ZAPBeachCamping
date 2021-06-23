using System;
using System.Collections.Generic;
using System.Linq;
using ZAPBeachCampingLib.Invoice;

namespace ZAPBeachCampingLib.Core
{
    public class Reservation : IInvoiceRows
    {
        internal string CustomerEmail { get; set; } // FOREIGN KEY
        internal string SpotNumber { get; set; } // FOREIGN KEY

        public int OrderNumber { get; internal set; } = -1;
        public Customer Customer { get; internal set; }
        public Spot Spot { get; internal set; }
        public List<CustomerType> CustomerTypes { get; internal set; }
        public List<Addition> Additions { get; internal set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsInvoiceSent { get; private set; } = false;
        public bool IsPayForCleaning { get; private set; }
        public SeasonType SeasonType { get; private set; }

        internal Reservation() { }
        public Reservation(Customer customer,
                           Spot spot,
                           DateTime startDate,
                           DateTime endDate,
                           List<CustomerType> customerTypes,
                           List<Addition> additions,
                           bool isPayForCleaning = false,
                           SeasonType seasonType = SeasonType.None)
        {
            Customer = customer;
            Spot = spot;
            StartDate = startDate;
            EndDate = endDate;
            CustomerTypes = customerTypes;
            Additions = additions;
            IsPayForCleaning = isPayForCleaning;
            SeasonType = seasonType;
        }

        /// <summary>
        /// Used to get total travel period in days
        /// </summary>
        public int GetTravelPeriodInDays()
        {
            return (int)(EndDate - StartDate).TotalDays;
        }

        /// <summary>
        /// Used to get total price of reservation
        /// </summary>
        public double GetTotalPrice()
        {
            PriceCalculator pC = new PriceCalculator(this);
            return pC.GetTotalPrice();
        }

        /// <summary>
        /// Used to get spot description
        /// </summary>
        public string GetSpotDescription()
        {
            if (SeasonType == SeasonType.None)
            {
                return Spot.ToString();
            }
            else
            {
                switch (SeasonType)
                {
                    case SeasonType.SeasonSpring:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i forår sæson";
                    case SeasonType.SeasonSummer:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i sommer sæson";
                    case SeasonType.SeasonAutumn:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i efterår sæson";
                    case SeasonType.SeasonWinter:
                        return $"Sæsonplads nr. {Spot.Number} på stor plads i vinter sæson";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// Used to get invoice rows of reservation, includes
        /// description, other and price for each row
        /// </summary>
        public InvoiceRow[] ToInvoiceRows()
        {
            PriceCalculator pC = new PriceCalculator(this);
            List<InvoiceRow> invoiceRows = new List<InvoiceRow>();

            invoiceRows.Add(new InvoiceRow(GetSpotDescription(), $"{GetTravelPeriodInDays()} døgn", $"{pC.GetTotalSpotPrice()} DKK"));
            invoiceRows.AddRange(GetSpecialAdditionsInvoiceRows());
            invoiceRows.AddRange(GetCustomerTypesInvoiceRows());
            invoiceRows.AddRange(GetAdditionsInvoiceRows());

            return invoiceRows.ToArray();
        }

        /// <summary>
        /// Used to get invoice rows of all special addtions
        /// </summary>
        private InvoiceRow[] GetSpecialAdditionsInvoiceRows()
        {
            PriceCalculator pC = new PriceCalculator(this);
            List<InvoiceRow> invoiceRows = new List<InvoiceRow>();

            if (SeasonType == SeasonType.None)
            {
                if (Spot.SpotType == SpotType.CampingSite)
                {
                    invoiceRows.Add(new InvoiceRow("Gratis pladsgebyr for hver 3 dag", Math.Floor(GetTravelPeriodInDays() / 3.0) + " døgns rabat", $"{pC.GetCampingSpotDiscountPrice()} DKK"));
                }

                invoiceRows.Add(new InvoiceRow("Ekstra god udsigt (75 DKK pr. døgn)", Spot.IsGoodView ? "Ja" : "Nej", $"{pC.GetGoodViewPrice()} DKK"));
                if (Spot.SpotType == SpotType.HutSite)
                {
                    invoiceRows.Add(new InvoiceRow("Slutrengøring (150 DKK)", IsPayForCleaning ? "Ja" : "Nej", $"{pC.GetHutSpotCleaningPrice()} DKK"));
                }
            }

            return invoiceRows.ToArray();
        }

        /// <summary>
        /// Used to get invoice rows of all customer types
        /// </summary>
        private InvoiceRow[] GetCustomerTypesInvoiceRows()
        {
            PriceCalculator pC = new PriceCalculator(this);
            List<InvoiceRow> invoiceRows = new List<InvoiceRow>();

            if (SeasonType == SeasonType.None)
            {
                invoiceRows.Add(new InvoiceRow(
                    $"Voksne ({Spot.Prices["ADULT_PRICE"].GetPrice()} DKK pr. voksen)",
                    $"Antal {CustomerTypes.FindAll(ct => ct == CustomerType.Adult).Count}",
                    $"{pC.GetTotalAdultPrice()} DKK"
                ));
                invoiceRows.Add(new InvoiceRow(
                     $"Børn ({Spot.Prices["CHILD_PRICE"].GetPrice()} DKK pr. barn)",
                     $"Antal {CustomerTypes.FindAll(ct => ct == CustomerType.Child).Count}",
                     $"{pC.GetTotalChildPrice()} DKK"
                 ));
                invoiceRows.Add(new InvoiceRow(
                     $"Hunde ({Spot.Prices["DOG_PRICE"].GetPrice()} DKK pr. hund)",
                     $"Antal {CustomerTypes.FindAll(ct => ct == CustomerType.Dog).Count}",
                     $"{pC.GetTotalDogPrice()} DKK"
                 ));
            }

            return invoiceRows.ToArray();
        }

        /// <summary>
        /// Used to get invoice rows of all additions
        /// </summary>
        private InvoiceRow[] GetAdditionsInvoiceRows()
        {
            List<InvoiceRow> invoiceRows = new List<InvoiceRow>();

            foreach (Addition addition in Additions.GroupBy(a => a.Name).Select(y => y.FirstOrDefault()))
            {
                int additionAmount = Additions.FindAll(a => a.Name == addition.Name).Count;
                double price = addition.Price * additionAmount;

                if (addition.IsDailyPayment)
                {
                    price *= GetTravelPeriodInDays();
                }

                invoiceRows.Add(new InvoiceRow(
                    $"{addition.Name} ({addition.Price} DKK{(addition.IsDailyPayment ? "pr. døgn" : "")})",
                    $"Antal {additionAmount}",
                    $"{price} DKK"
                ));
            }

            return invoiceRows.ToArray();
        }
    }
}