using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ItemReservation
    {
        public long ItemReservationId { get; set; }
        public long AtpitemId { get; set; }
        public string ShippingLocaionExternalId { get; set; }
        public int? ShippingLocaionInternalId { get; set; }
        public string PickupLocaionExternalId { get; set; }
        public int? PickupLocaionInternalId { get; set; }
        public bool? QuantityReserved { get; set; }
        public int? ServiceStatusId { get; set; }
        public DateTime? CreateDatetimeUtc { get; set; }
        public DateTime? UpdateDatetimeUtc { get; set; }

        public virtual AtpItem Atpitem { get; set; }
        public virtual ServiceStatus ServiceStatus { get; set; }
    }
}
