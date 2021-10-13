using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class SearchOrdersViewModel : PagingParameters
    {
        public int? Id { get; set; }
        public int? Stock_Id { get; set; }
    }
}
