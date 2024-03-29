﻿using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Sliders
{
    public class SliderDTO : BaseDTO
    {
        public string Name { get; set; }
        public SliderType? SliderType { get; set; }
        public int? SliderTypeId { get; set; }
        public string Image
        {
            get
            {
                return "/Uploads/Sliders/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
