using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Markets
{
    public class AddMarketViewModel : NamedViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }
    }
}
