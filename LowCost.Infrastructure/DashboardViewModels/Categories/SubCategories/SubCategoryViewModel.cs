using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.SubCategories
{
    public class SubCategoryViewModel : BaseNamedViewModel
    {
        [Display(Name = "Category")]
        public int Category_Id { get; set; }


        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
