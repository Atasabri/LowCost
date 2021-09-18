using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products
{
    public class ListingProductViewModel : BaseNamedViewModel
    {
        [Display(Name = "Sub Category Name")]
        public string SubCategoryName { get; set; }
        [Display(Name = "Sub Category")]
        public int SubCategory_Id { get; set; }

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Brand")]
        public int Brand_Id { get; set; }

        public List<PriceViewModel> Prices { get; set; }
    }
}
