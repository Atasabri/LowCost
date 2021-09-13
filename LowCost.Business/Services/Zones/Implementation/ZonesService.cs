using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Zones.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Zones;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zones.Implementation
{
    public class ZonesService : IZonesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ZonesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<ZoneDTO>> GetZonesAsync(PagingParameters pagingParameters)
        {
            var Zones = await _unitOfWork.ZonesRepository.GetElementsAsync(Zone => true, pagingParameters);

            var ZonesDTOs = Zones.ToMappedPagedResult<Zone, ZoneDTO>(_mapper);
            return ZonesDTOs;
        }
    }
}
