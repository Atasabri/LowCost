using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Offers
{
    public class EditOfferViewModel : BaseNamedViewModel
    {
        [Display(Name = "Is New")]
        public bool IsNew { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTimeProvider.GetEgyptDateTime();
        public IFormFile Photo { get; set; }

    }
}
