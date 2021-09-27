using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Products
{
    public class PricesDTO
    {
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int? MaxQuantityPerOrder { get; set; }
        public int Market_Id { get; set; }
        public string MarketName { get; set; }
    }
}
