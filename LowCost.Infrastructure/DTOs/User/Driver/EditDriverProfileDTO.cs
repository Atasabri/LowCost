﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User.Driver
{
    public class EditDriverProfileDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public IFormFile Photo { get; set; }
    }
}
