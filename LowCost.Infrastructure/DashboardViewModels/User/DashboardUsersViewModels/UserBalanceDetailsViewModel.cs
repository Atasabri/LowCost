using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels
{
    public class UserBalanceDetailsViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
