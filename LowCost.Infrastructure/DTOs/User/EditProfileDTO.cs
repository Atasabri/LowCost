using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User
{
    public class EditProfileDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Zone_Id { get; set; }

        public IFormFile Photo { get; set; }

    }
}
