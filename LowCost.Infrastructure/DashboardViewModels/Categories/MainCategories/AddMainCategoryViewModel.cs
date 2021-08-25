using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories
{
    public class AddMainCategoryViewModel : NamedViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }
    }
}
