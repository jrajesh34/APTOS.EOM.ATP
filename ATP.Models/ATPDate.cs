﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
    public class ATPDate
    {
        public string DeliveryWindow { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public DateTime PickingDateTime { get; set; }
        public DateTime ShippingDateTime { get; set; }
        public DateTime DCDeliveryDateTime { get; set; }
        public int LeadTimeDays { get; set; }
    }
}
