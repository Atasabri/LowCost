using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products.Prices
{
    public class AddPriceViewModel
    {
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        [Required]
        public int Market_Id { get; set; }
    }
}
