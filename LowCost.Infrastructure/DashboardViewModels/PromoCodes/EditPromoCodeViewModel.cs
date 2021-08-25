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
        public double DiscountPercent { get; set; }
    }
}
