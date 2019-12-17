using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
    public class ItemDimension
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal ItemWeight { get; set; }
        public string Carrier { get; set; }
        public string ServiceLevel { get; set; }
    }
}