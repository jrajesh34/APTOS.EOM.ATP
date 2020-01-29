using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ATPTransaction
    {
        public Int64 ATPTransactionId { get; set; }
        public int CartId { get; set; }
        public int LineId { get; set; }
        public int SKUId { get; set; }
        public int ItemSupplierId { get; set; }
        public bool IsInventoryReserved { get; set; }
        public int quantityreserved { get; set; }
        public string DeliveryWindow { get; set; }
        public DateTime DeliveryDateTIme { get; set; }
        public DateTime PickingDateTime { get; set; }
        public DateTime ShippingDateTime { get; set; }
        public DateTime DCDeliveryDateTime { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime Lastmodifieddatetime { get; set; }
        public int StatusId { get; set; }
    }
}
