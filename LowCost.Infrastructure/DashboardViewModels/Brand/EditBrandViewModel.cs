using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Brand
{
    public class EditBrandViewModel : BaseNamedViewModel
    {
        [Required]
        [Display(Name = "View In App")]
        public bool ViewInApp { get; set; }
        public IFormFile Photo { get; set; }

    }
}
