﻿using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class AtpItem
    {
        public AtpItem()
        {
            ItemDelivery = new HashSet<ItemDelivery>();
            ItemReservation = new HashSet<ItemReservation>();
        }

        public long AtpitemId { get; set; }
        public long AtpTransactionId { get; set; }
        public int LineId { get; set; }
        public long InternalItemId { get; set; }
        public long? ExternalProductId { get; set; }
        public long? InternalProductId { get; set; }
        public string Shippingmethod { get; set; }
        public int? QuantityRequested { get; set; }
        public bool? NonMerchFlag { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public DateTime? CreateDatetimeUtc { get; set; }
        public DateTime? UpdateDatetimeUtc { get; set; }

        public virtual AtpTransaction AtpTransaction { get; set; }
        public virtual ICollection<ItemDelivery> ItemDelivery { get; set; }
        public virtual ICollection<ItemReservation> ItemReservation { get; set; }
    }
}
