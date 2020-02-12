using ATP.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
    public class ATPResponse
    {
        public int ATPId { get; set; }
        public int CartId { get; set; }
        public string ATPResponseType { get; set; }
        public string ATPResponseCode { get; set; }
        public string ATPResponseMessage { get; set; }
        public string LogisticsResponseType { get; set; }
        public string LogisticsResponseCode { get; set; }
        public string LogisticsResponseMessage { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public decimal TotalShippingCost { get; set; }
        public List<ItemDto> ItemATPResponse { get; set; }

    }
}
