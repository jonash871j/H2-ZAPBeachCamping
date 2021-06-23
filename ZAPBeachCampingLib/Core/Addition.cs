namespace ZAPBeachCampingLib.Core
{
    public class Addition
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public bool IsDailyPayment { get; private set; }

        internal Addition() 
        {
        }

        public Addition(string name, double price, bool isDailyPayment)
        {
            Name = name;
            Price = price;
            IsDailyPayment = isDailyPayment;
        }
    }
}
