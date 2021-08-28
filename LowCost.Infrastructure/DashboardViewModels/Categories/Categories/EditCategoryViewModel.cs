using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.Categories
{
    public class EditCategoryViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }
        public IFormFile Banner { get; set; }


        [Required]
        [Display(Name = "Main Category")]
        public int MainCategory_Id { get; set; }
        [Required]
        [Display(Name = "View In App")]
        public bool ViewInApp { get; set; }
    }
}
