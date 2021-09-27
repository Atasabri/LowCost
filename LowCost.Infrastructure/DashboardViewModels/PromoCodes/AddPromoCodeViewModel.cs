using System.ComponentModel.DataAnnotations;

namespace LowCost.Infrastructure.DashboardViewModels.PromoCodes
{
    public class AddPromoCodeViewModel
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
