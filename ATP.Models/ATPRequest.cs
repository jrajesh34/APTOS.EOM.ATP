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
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public List<ItemDto> Items { get; set; }
       // public ShipToAddress ShipAddress { get; set; }
      //  public ItemDimension ItemDimension { get; set; }
    }
}
