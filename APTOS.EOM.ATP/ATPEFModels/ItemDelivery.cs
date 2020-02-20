using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ItemDelivery
    {
        public long ItemDeliveryId { get; set; }
        public long AtpitemId { get; set; }
        public string Carrier { get; set; }
        public string ServiceLevel { get; set; }
        public int? GroupId { get; set; }
        public decimal? ItemDeliveryCost { get; set; }
        public string DeliveryTimeWindow { get; set; }
        public int? ServiceStatusId { get; set; }
        public DateTime? DeliveryDatetimeUtc { get; set; }
        public DateTime? PickDatetimeUtc { get; set; }
        public DateTime? ShippingDatetimeUtc { get; set; }
        public DateTime? DcDeliveryDatetimeUtc { get; set; }
        public int? LeadTimeInDays { get; set; }
        public DateTime CreateDatetimeUtc { get; set; }
        public DateTime UpdateDatetimeUtc { get; set; }

        public virtual AtpItem Atpitem { get; set; }
        public virtual ServiceStatus ServiceStatus { get; set; }
    }
}
