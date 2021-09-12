using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Zoons
{
    public class ZoonViewModel : BaseNamedViewModel
    {
        [Display(Name = "Stock Name")]
        public string StockName { get; set; }

        public int Stock_Id { get; set; }
    }
}
