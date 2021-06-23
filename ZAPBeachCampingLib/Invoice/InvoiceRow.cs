
namespace ZAPBeachCampingLib.Invoice
{
    public class InvoiceRow
    {
        public string Description { get; private set; }
        public string Other { get; private set; }
        public string Price { get; private set; }

        public InvoiceRow(string description, string other, string price)
        {
            Description = description;
            Other = other;
            Price = price;
        }
    }
}
