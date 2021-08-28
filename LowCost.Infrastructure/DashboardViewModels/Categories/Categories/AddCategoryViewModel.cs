using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.Categories
{
    public class AddCategoryViewModel : NamedViewModel
    {
        [Required]
        public bool ViewInApp { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public IFormFile Banner { get; set; }

        [Required]
        [Display(Name = "Main Category")]
        public int MainCategory_Id { get; set; }

    }
}
