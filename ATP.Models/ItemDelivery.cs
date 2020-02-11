using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ItemDelivery
    {
        public Int64 ItemDeliveryId { get; set; }
        public Int64 ATPItemId { get; set; }
        public string Carrier { get; set; }
        public string ServiceLevel { get; set; }
        public int GroupId { get; set; }
        public decimal? ItemDeliveryCost { get; set; }
        public string DeliveryTimeWindow { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime? DeliveryDateTimeUtc { get; set; }
        public DateTime? PickDateTimeUtc { get; set; }
        public DateTime? ShippingDateTimeUtc { get; set; }
        public DateTime? DCDeliveryDateTimeUtc { get; set; }
        public int LeadTimeInDays { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
    }
}
