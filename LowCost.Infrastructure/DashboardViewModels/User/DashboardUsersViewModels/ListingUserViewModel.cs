using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels
{
    public class ListingUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public int OrdersCount { get; set; }
        public double OrdersTotal { get; set; }
    }
}
