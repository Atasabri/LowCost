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
        public IFormFile Photo { get; set; }

    }
}
