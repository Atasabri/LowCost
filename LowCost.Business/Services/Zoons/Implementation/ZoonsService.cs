using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Zoons.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Zoons;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zoons.Implementation
{
    public class ZoonsService : IZoonsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ZoonsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<ZoonDTO>> GetZoonsAsync(PagingParameters pagingParameters)
        {
            var zoons = await _unitOfWork.ZoonsRepository.GetElementsAsync(zoon => true, pagingParameters);

            var zoonsDTOs = zoons.ToMappedPagedResult<Zoon, ZoonDTO>(_mapper);
            return zoonsDTOs;
        }
    }
}
