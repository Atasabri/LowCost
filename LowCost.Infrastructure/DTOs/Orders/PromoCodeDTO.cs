using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class PromoCodeDTO
    {
        public bool PromoCodeFound { get; set; }
        public double DiscountPercent { get; set; }
        public bool FreeDelivery { get; set; }

        public int? Category_Id { get; set; }
        public int? SubCategory_Id { get; set; }
        public int? Zone_Id { get; set; }
    }
}
