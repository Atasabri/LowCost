using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Products;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using LowCost.Infrastructure.DTOs.Brand;
using LowCost.Infrastructure.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void ProductsMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();

            CreateMap<Product, ListingProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();

            CreateMap<Prices, PricesDTO>()
                    .ForMember(dest => dest.MarketName, opt => opt.MapFrom(src => src.Market.GetType().GetProperty(localizedName).GetValue(src.Market)))
                    .ReverseMap();
        }

        void DashboardProductsMapping()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.OfferName, opt => opt.MapFrom(src => src.Offer_Id.HasValue? src.Offer.Name : null))
                .ReverseMap();
            CreateMap<Product, ListingProductViewModel>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ReverseMap();
            CreateMap<AddProductViewModel, Product>().ReverseMap();
            CreateMap<EditProductViewModel, Product>().ReverseMap();

            // Mapping Prices View Models
            CreateMap<AddPriceViewModel, Prices>().ReverseMap();
            CreateMap<EditPriceViewModel, Prices>().ReverseMap();
            CreateMap<Prices, PriceViewModel>()
                .ForMember(dest => dest.MarketName, opt => opt.MapFrom(src => src.Market.Name))
                .ReverseMap();
        }
    }
}
