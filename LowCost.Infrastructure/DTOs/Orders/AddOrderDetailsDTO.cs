using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class AddOrderDetailsDTO
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public int Market_Id { get; set; }
    }
}
