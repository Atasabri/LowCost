using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.Categories
{
    public class CategoryViewModel : BaseNamedViewModel
    {
        [Display(Name = "Main Category Name")]
        public string MainCategoryName { get; set; }
        [Display(Name = "Main Category")]
        public int MainCategory_Id { get; set; }
        [Display(Name = "View In App")]
        public bool ViewInApp { get; set; }
    }
}
