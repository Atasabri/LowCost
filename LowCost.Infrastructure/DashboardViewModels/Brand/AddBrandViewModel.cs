using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Brand
{
    public class AddBrandViewModel : NamedViewModel
    {
        [Required]
        [Display(Name = "View In App")]
        public bool ViewInApp { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
