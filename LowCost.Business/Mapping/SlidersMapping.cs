using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Sliders;
using LowCost.Infrastructure.DTOs.Sliders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void SlidersMapping()
        {
            CreateMap<Slider, SliderDTO>().ReverseMap();
        }

        void DashboardSlidersMapping()
        {
            CreateMap<Slider, SliderViewModel>().ReverseMap();
            CreateMap<AddSliderViewModel, Slider>().ReverseMap();
            CreateMap<EditSliderViewModel, Slider>().ReverseMap();
        }
    }
}
