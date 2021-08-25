using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products.Prices
{
    public class PriceViewModel : BaseViewModel
    {
        public double Price { get; set; }
        [Display(Name = "Old Price")]
        public double? OldPrice { get; set; }
        [Display(Name = "Market")]
        public int Market_Id { get; set; }
        public int Product_Id { get; set; }
        public string MarketName { get; set; }
    }
}
