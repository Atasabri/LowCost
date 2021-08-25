using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.BaseViewModels
{
    public class BaseNamedViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Arabic Name")]
        public string Name_AR { get; set; }
    }
}
