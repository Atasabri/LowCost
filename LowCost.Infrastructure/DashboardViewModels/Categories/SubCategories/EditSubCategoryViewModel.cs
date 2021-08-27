using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.SubCategories
{
    public class EditSubCategoryViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }
        public IFormFile Banner { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }
    }
}
