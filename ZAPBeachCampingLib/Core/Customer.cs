namespace ZAPBeachCampingLib.Core
{
    public class Customer
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public string City { get; internal set; }
        public string Address { get; internal set; }
        public string PhoneNumber { get; internal set; }
        
        internal Customer() 
        { 
        }
        public Customer(string firstName, string lastName, string email, string city, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Used to check if customer is valid
        /// </summary>
        /// <param name="errorMsg">Returns error msg on failure</param>
        /// <returns>true if succesfull</returns>
        public bool IsValid(out string errorMsg)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(PhoneNumber))
            {
                errorMsg = "Vi mangler nogle oplysninger om dig.";
                return false;
            }
            errorMsg = "";
            return true;
        }
    }
}
