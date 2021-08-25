using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Identity
{
    public class RegisterState
    {
        public bool RegisterSuccessfully { get; set; }
        public string Token { get; set; }
        public string User_Id { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
