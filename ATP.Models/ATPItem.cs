using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ATPItem
    {
        public Int64 ATPItemId { get; set; }
        public Int64 ATPTransactionId { get; set; }
        public int LineId { get; set; }
        public Int64 InternalItemId { get; set; }
        public Int64 InternalProductId { get; set; }
        public Int64 ExternalProductId { get; set; }
        public string ShippingMethod { get; set; }
        public int? QuantityRequested { get; set; }
        public bool NonMerchFlag { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public ItemDelivery ItemDelivery { get; set; }
        public ItemReservation ItemReservation { get; set; }
    }
}
