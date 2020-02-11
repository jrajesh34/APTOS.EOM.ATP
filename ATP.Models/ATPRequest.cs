using ATP.Models.DTO;
using ATP.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
    public class ATPRequest
    {
        public ActionType ActionType { get; set; }
        public int ATPId { get; set; }
        public int CartId { get; set; }
        public bool CreateReservation { get; set; }
        public bool GetDeliveryInfo { get; set; }
        public RequestType RequestType { get; set; }
        public string RoutingRuleId { get; set; }
        public string CustomData1 { get; set; }
        public string CustomData2 { get; set; }
        public string CustomData3 { get; set; }
        public string CustomData4 { get; set; }
        public string CustomData5 { get; set; }
        public List<ATPItem> Items { get; set; }
        public ShipToAddress ShipAddress { get; set; }
        public ItemDimension ItemDimension { get; set; }
    }
}
