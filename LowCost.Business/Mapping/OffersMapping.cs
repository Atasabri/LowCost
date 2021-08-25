using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Offers;
using LowCost.Infrastructure.DTOs.Offers;
using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.DTOs.User.Address;
using LowCost.Infrastructure.DTOs.User.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void OffersMapping()
        {
            CreateMap<Offer, OfferDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();
        }

        void DashboardOffersMapping()
        {
            CreateMap<Offer, OfferViewModel>().ReverseMap();
            CreateMap<AddOfferViewModel, Offer>().ReverseMap();
            CreateMap<EditOfferViewModel, Offer>().ReverseMap();
        }
    }
}
