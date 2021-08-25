using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Brands.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Brand;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Brands.Implementation
{
    public class BrandsService : IBrandsService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public BrandsService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<BrandDTO>> GetBrandsAsync(PagingParameters pagingParameters)
        {
            var brands = await _unitofwork.BrandsRepository.GetElementsAsync(brand => true, pagingParameters);

            var brandsDTOs = brands.ToMappedPagedResult<Brand, BrandDTO>(_mapper);
            return brandsDTOs;
        }
    }
}
