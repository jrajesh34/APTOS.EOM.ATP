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
        public string ResponseType { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string LogisticsResponseType { get; set; }
        public string LogisticsResponseCode { get; set; }
        public string LogisticsResponseMessage { get; set; }
        public decimal TotalShippingCost { get; set; }
        public List<ATPItem> ItemATPResponse { get; set; }
    }
}
