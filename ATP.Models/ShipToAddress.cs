﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
    public class ShipToAddress
    {
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
    }
}
