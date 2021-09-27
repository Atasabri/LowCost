using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products.Prices
{
    public class EditPriceViewModel : BaseViewModel
    {
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        [Display(Name = "Max Quantity Per Order")]
        public int? MaxQuantityPerOrder { get; set; }
        [Required]
        public int Market_Id { get; set; }
        [Required]
        public int Product_Id { get; set; }
    }
}
