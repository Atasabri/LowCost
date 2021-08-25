using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Brand;
using LowCost.Infrastructure.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void BrandsMapping()
        {
            CreateMap<Brand, BrandDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                    .ReverseMap();
        }
        void DashboardBrandsMapping()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<AddBrandViewModel, Brand>().ReverseMap();
            CreateMap<EditBrandViewModel, Brand>().ReverseMap();
        }
    }
}
