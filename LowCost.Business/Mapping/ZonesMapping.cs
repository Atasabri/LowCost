using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Zones;
using LowCost.Infrastructure.DTOs.Zones;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void ZonesMapping()
        {
            CreateMap<Zone, ZoneDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                    .ReverseMap();
        }

        void DashboardZonesMapping()
        {
            CreateMap<Zone, ZoneViewModel>()
               .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Stock.Name))
               .ReverseMap();
            CreateMap<AddZoneViewModel, Zone>().ReverseMap();
            CreateMap<EditZoneViewModel, Zone>().ReverseMap();
        }
    }
}
