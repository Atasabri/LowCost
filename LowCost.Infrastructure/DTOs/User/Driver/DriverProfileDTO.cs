using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User.Driver
{
    public class DriverProfileDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
    }
}
