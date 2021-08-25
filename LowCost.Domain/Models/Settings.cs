using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Settings : BaseModel
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public TypeCode Type { get; set; }
    }
}
