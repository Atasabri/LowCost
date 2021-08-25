using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class SmsCode : BaseModel
    {
        public int Code { get; set; }
        public string Phone { get; set; }
        public string SmsId { get; set; }
        public DateTime Expire { get; set; }
    }
}
