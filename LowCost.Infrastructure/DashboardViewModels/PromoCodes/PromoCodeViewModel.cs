using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.PromoCodes
{
    public class PromoCodeViewModel : BaseViewModel
    {
        public string Code { get; set; }
        [Display(Name = "Discount Percent")]
        public double DiscountPercent { get; set; }
        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }

        public int? Category_Id { get; set; }
        public int? SubCategory_Id { get; set; }
        public int? Zone_Id { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Sub Category Name")]
        public string SubCategoryName { get; set; }
        [Display(Name = "Zone Name")]
        public string ZoneName { get; set; }
    }
}
