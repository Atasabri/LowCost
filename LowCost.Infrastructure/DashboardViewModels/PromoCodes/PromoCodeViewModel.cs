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
        public double DiscountPercent { get; set; }
    }
}
