using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ItemReservation
    {
        public long ItemReservationId { get; set; }
        public long AtpitemId { get; set; }
        public string ShippingLocationExternalId { get; set; }
        public int ShippingLocationInternalId { get; set; }
        public string PickupLocationExternalId { get; set; }
        public int PickupLocationInternalId { get; set; }
        public bool IsQuantityReservedFlag { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime CreateDatetimeUtc { get; set; }
        public DateTime UpdateDatetimeUtc { get; set; }

        public virtual AtpItem Atpitem { get; set; }
        public virtual ServiceStatus ServiceStatus { get; set; }
    }
}
