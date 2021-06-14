using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Addition
    {
        #region Properties
        public string Name { get; private set; }
        public double Price { get; private set; }
        public bool IsDaily { get; private set; }
        #endregion

        #region Constructors

        internal Addition() 
        {
        }

        public Addition(string name, double price, bool isDaily)
        {
            Name = name;
            Price = price;
            IsDaily = isDaily;
        }
        #endregion
    }
}
