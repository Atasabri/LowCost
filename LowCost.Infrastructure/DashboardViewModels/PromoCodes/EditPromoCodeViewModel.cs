using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.PromoCodes
{
    public class EditPromoCodeViewModel : BaseViewModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Discount Percent")]
        public double DiscountPercent { get; set; }
        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }

        [Display(Name = "Category")]
        public int? Category_Id { get; set; }
        [Display(Name = "Sub Category")]
        public int? SubCategory_Id { get; set; }
        [Display(Name = "Zone")]
        public int? Zone_Id { get; set; }
    }
}
