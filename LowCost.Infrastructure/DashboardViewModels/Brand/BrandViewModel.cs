using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Brand
{
    public class BrandViewModel : BaseNamedViewModel
    {
        [Display(Name = "View In App")]
        public bool ViewInApp { get; set; }
    }
}
