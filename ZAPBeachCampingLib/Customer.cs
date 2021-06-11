using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Customer
    {
        #region Properties

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public string City { get; internal set; }
        public string Address { get; internal set; }
        public string PhoneNumber { get; internal set; }
        #endregion
        
        #region Constructor

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

        
        #endregion
    }
}
