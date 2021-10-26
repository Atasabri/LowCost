using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Offers
{
    public class AddOfferViewModel : NamedViewModel
    {
        [Display(Name = "Is New")]
        public bool IsNew { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
