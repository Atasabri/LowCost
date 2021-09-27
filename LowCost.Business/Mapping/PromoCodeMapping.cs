using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.PromoCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardPromoCodesMapping()
        {
            CreateMap<PromoCode, PromoCodeViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.ZoneName, opt => opt.MapFrom(src => src.Zone.Name))
                .ReverseMap();
            CreateMap<AddPromoCodeViewModel, PromoCode>().ReverseMap();
            CreateMap<EditPromoCodeViewModel, PromoCode>().ReverseMap();
        }
    }
}
