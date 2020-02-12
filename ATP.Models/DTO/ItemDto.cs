using System;

namespace ATP.Models.DTO
{
    public class ItemDto
    {
        public int SKUId { get; set; }
        public bool DigitalGood { get; set; }
        public int Quantity { get; set; }
        public int LineID { get; set; }
        public int GroupID { get; set; }
        public string ShippingMethod { get; set; }
        public int SupplierIdForPickUp { get; set; }
        public int SupplierIdDForShip { get; set; }
        public int QuantityRequested { get; set; }
        public int QuantityReserved { get; set; }
        public decimal? ShippingCost { get; set; }
        public string CurrencyCode { get; set; }
        public ATPDate Date { get; set; }
        public DateTime RequestedDeliveryDate { get; set; }
        public string RequestedDeliveryWindow { get; set; }
        public ShipToAddress ShipToAddress { get; set; }
        public ItemDimension ItemDimenstion { get; set; }
        public string ATPResponseType { get; set; }
        public string ATPResponseCode { get; set; }
        public string ATPResponseMessage { get; set; }
        public string LogisticsResponseType { get; set; }
        public string LogisticsResponseCode { get; set; }
        public string LogisticsResponseMessage { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public string Carrier { get; set; }
        public string ServiceLevel { get; set; }
    }
}
