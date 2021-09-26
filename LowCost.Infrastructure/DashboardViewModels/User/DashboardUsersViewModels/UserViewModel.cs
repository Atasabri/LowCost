using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Current Langauge")]
        public Languages CurrentLangauge { get; set; }
        public int? Zone_Id { get; set; }

        [Display(Name = "Zone Name")]
        public string ZoneName { get; set; }

        public double Balance { get; set; }

        [Display(Name = "Login Provider")]
        public string LoginProvider { get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}
