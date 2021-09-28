using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Sliders
{
    public class EditSliderViewModel : BaseViewModel
    {
        public IFormFile Photo { get; set; }

        [Display(Name = "Slider Type")]
        public SliderType? SliderType { get; set; }
        public int? SliderTypeId { get; set; }
    }
}
