using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels
{
    public class NotifyUsersViewModel
    {
        public PagingParameters Paging { get; set; }

        [Display(Name = "Notify All Users")]
        public bool AllUsers { get; set; }
        public List<string> SelectedUsers { get; set; }

        public string Header { get; set; }

        [Display(Name = "Header (Arabic)")]
        public string Header_AR { get; set; }

        public string Message { get; set; }

        [Display(Name = "Message (Arabic)")]
        public string Message_AR { get; set; }
    }
}
