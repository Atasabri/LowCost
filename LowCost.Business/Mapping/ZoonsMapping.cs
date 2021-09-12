using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Zoons;
using LowCost.Infrastructure.DTOs.Zoons;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void ZoonsMapping()
        {
            CreateMap<Zoon, ZoonDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                    .ReverseMap();
        }

        void DashboardZoonsMapping()
        {
            CreateMap<Zoon, ZoonViewModel>()
               .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Stock.Name))
               .ReverseMap();
            CreateMap<AddZoonViewModel, Zoon>().ReverseMap();
            CreateMap<EditZoonViewModel, Zoon>().ReverseMap();
        }
    }
}
