using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Offers
{
    public class OfferViewModel : BaseNamedViewModel
    {
        [Display(Name = "Is New")]
        public bool IsNew { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
