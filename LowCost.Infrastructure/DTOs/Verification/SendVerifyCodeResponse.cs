using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Verification
{
    public class SendVerifyCodeResponse
    {
        public string SMSID { get; set; }
        public string Error { get; set; }
    }
}
