using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products.Prices
{
    public class EditProductPriceUsingPriceIdModel
    {
        public double? OldPrice { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }

    }
}
