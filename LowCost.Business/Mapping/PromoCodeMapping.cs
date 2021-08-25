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
            CreateMap<PromoCode, PromoCodeViewModel>().ReverseMap();
            CreateMap<AddPromoCodeViewModel, PromoCode>().ReverseMap();
            CreateMap<EditPromoCodeViewModel, PromoCode>().ReverseMap();
        }
    }
}
