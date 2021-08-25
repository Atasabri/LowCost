using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class OrderDetailsDTO
    {
        public int Product_Id { get; set; }
        public int Market_Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }
        public string MarketName { get; set; }

        public string Image
        {
            get
            {
                return string.Format("/Uploads/Products/{0}.jpg", this.Product_Id);
            }
        }
    }
}
