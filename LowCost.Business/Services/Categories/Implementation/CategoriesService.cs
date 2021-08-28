using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Categories.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Categories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Implementation
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public CategoriesService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<MainCategoryDTO>> GetMainCategoriesAsync(PagingParameters pagingParameters)
        {
            var mainCategories = await _unitofwork.MainCategoriesRepository.GetElementsAsync(mainCat => true, pagingParameters);

            var mainCategoriesDTOs = mainCategories.ToMappedPagedResult<MainCategory, MainCategoryDTO>(_mapper);
            return mainCategoriesDTOs;
        }

        public async Task<PagedResult<CategoryDTO>> GetCategoriesUsingMainCategoryIdAsync(int mainCatId, PagingParameters pagingParameters)
        {
            var categories = await _unitofwork.CategoriesRepository
                .GetElementsWithOrderAsync(Cat => Cat.MainCategory_Id == mainCatId && Cat.ViewInApp , pagingParameters, cat => cat.OrderKey, OrderingType.Ascending);

            var categoriesDTOs = categories.ToMappedPagedResult<Category, CategoryDTO>(_mapper);

            return categoriesDTOs;
        }

        public async Task<PagedResult<CategoryDTO>> GetCategoriesAsync(PagingParameters pagingParameters)
        {
            var categories = await _unitofwork.CategoriesRepository
                .GetElementsWithOrderAsync(Cat => Cat.ViewInApp, pagingParameters, Cat => Cat.OrderKey, OrderingType.Ascending);

            var categoriesDTOs = categories.ToMappedPagedResult<Category, CategoryDTO>(_mapper);

            return categoriesDTOs;
        }

        public async Task<PagedResult<CategoryIncludeSubCategoriesDTO>> GetCategoriesIncludeSubCategoriesAsync(int mainCatId, PagingParameters pagingParameters)
        {
            var categories = await _unitofwork.CategoriesRepository
                .GetElementsWithOrderAsync(Cat => Cat.MainCategory_Id == mainCatId && Cat.ViewInApp, pagingParameters, Cat => Cat.OrderKey,
                OrderingType.Ascending, nameof(Category.SubCategories));

            var categoriesDTOs = categories.ToMappedPagedResult<Category, CategoryIncludeSubCategoriesDTO>(_mapper);

            return categoriesDTOs;
        }

        public async Task<PagedResult<SubCategoryDTO>> GetSubCategoriesAsync(int catId, PagingParameters pagingParameters)
        {
            var subCategories = await _unitofwork.SubCategoriesRepository
                .GetElementsAsync(subCat => subCat.Category_Id == catId, pagingParameters);

            var subCategoriesDTOs = subCategories.ToMappedPagedResult<SubCategory, SubCategoryDTO>(_mapper);

            return subCategoriesDTOs;
        }
    }
}
