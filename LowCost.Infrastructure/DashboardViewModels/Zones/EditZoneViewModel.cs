using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Zones
{
    public class EditZoneViewModel : BaseNamedViewModel
    {
        [Required]
        [Display(Name = "Stock")]
        public int Stock_Id { get; set; }
    }
}
