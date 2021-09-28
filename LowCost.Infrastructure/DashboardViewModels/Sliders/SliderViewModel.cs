using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Sliders
{
    public class SliderViewModel : BaseViewModel
    {
        [Display(Name = "Slider Type")]
        public SliderType? SliderType { get; set; }
        [Display(Name = "View Slider Type Page")]
        public int? SliderTypeId { get; set; }
    }
}
