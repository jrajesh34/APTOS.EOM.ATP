using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ItemReservation
    {
        public Int64 ItemReservationId { get; set; }
        public Int64 ATPItemId { get; set; }
        public string ShippingLocatonExternalId { get; set; }
        public string PickupLocatonExternalId { get; set; }
        public int ShippingLocatonInternalId { get; set; }
        public int PickupLocatonInternalId { get; set; }
        public bool QuantityReserved { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
    }
}
