using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Customer
    {
        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        #endregion
        
        #region Constructor
        public Customer(string firstName, string lastName, string email, string city, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        
        #endregion
    }
}
