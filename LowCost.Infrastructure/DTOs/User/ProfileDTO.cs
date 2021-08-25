using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User
{
    public class ProfileDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string ExternalLoginId { get; set; }
        public string Provider { get; set; }

    }
}
