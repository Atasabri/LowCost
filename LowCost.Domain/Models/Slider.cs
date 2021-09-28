using LowCost.Domain.Models.BaseModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Slider : BaseModel
    {
        public SliderType? SliderType { get; set; }
        public int? SliderTypeId { get; set; }
    }
}
