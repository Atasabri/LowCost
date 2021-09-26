using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.DashboardViewModels.User;
using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.DTOs.User.Address;
using LowCost.Infrastructure.DTOs.User.Driver;
using LowCost.Infrastructure.DTOs.User.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void UsersMapping()
        {
            CreateMap<User, ProfileDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.ZoneName, opt => opt.MapFrom(src => src.Zone.GetType().GetProperty(localizedName).GetValue(src.Zone)))
                .ReverseMap();

            CreateMap<User, DriverProfileDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<User, DriverViewModel>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<ListingProductDTO, Favorites>()               
                .ForMember(dest => dest.Product_Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<AddAddressDTO, Address>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<AddPaymentMethodDTO, PaymentMethod>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
        }
        void DashboardAdminsMapping()
        {
            CreateMap<AddNewAdminViewModel, User>()
                .ReverseMap();
            CreateMap<AdminViewModel, User>()
                .ReverseMap();
        }

        void DashboardUsersMapping()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.ZoneName, opt => opt.MapFrom(src => src.Zone.Name))
                .ReverseMap();
            CreateMap<ListingUserViewModel, User>()
                .ReverseMap();
            CreateMap<AddressViewModel, Address>()
                .ReverseMap();

            CreateMap<User, UserBalanceDetailsViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
