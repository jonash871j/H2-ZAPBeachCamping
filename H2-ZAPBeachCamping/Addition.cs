﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPBeachCampingLib
{
    public class Addition
    {
        #region Properties
        public string Name { get; private set; }
        public double Price { get; private set; }
        #endregion

        #region Constructors

        public Addition(string name, double price)
        {
            Name = name;
            Price = price;
        }
        #endregion
    }
}
