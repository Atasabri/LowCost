using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories;
using LowCost.Infrastructure.DashboardViewModels.Categories.SubCategories;
using LowCost.Infrastructure.DTOs.Categories;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        public void CategoriesMapping()
        {
            CreateMap<MainCategory, MainCategoryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();

            CreateMap<Category, CategoryIncludeSubCategoriesDTO>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                 .ReverseMap();

            CreateMap<SubCategory, SubCategoryDTO>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();
        }

        public void DashboardCategoriesMapping()
        {
            CreateMap<AddMainCategoryViewModel, MainCategory>().ReverseMap();
            CreateMap<EditMainCategoryViewModel, MainCategory>().ReverseMap();
            CreateMap<MainCategoryViewModel, MainCategory>().ReverseMap();

            CreateMap<AddCategoryViewModel, Category>().ReverseMap();
            CreateMap<EditCategoryViewModel, Category>().ReverseMap();
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name))
                .ReverseMap();

            CreateMap<AddSubCategoryViewModel, SubCategory>().ReverseMap();
            CreateMap<EditSubCategoryViewModel, SubCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
        }
    }
}
