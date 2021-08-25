using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Brand
{
    public class EditBrandViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }

    }
}
