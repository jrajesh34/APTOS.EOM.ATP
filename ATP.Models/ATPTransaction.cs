﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ATPTransaction
    {
        public Int64 ATPTransactionId { get; set; }
        public Int64 CartId { get; set; }
        public int? OrderId { get; set; }
        public decimal? TotalDeliveryCost { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }

    }
}
