using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories
{
    public class EditMainCategoryViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }
    }
}
