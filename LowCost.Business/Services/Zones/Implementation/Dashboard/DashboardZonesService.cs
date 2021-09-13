using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Zones.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Zones;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zones.Implementation.Dashboard
{
    public class DashboardZonesService : IDashboardZonesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardZonesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateZoneAsync(AddZoneViewModel addZoneViewModel)
        {
            var createState = new CreateState();
            var zone = _mapper.Map<AddZoneViewModel, Zone>(addZoneViewModel);

            await _unitOfWork.ZonesRepository.CreateAsync(zone);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Zone");
            return createState;
        }

        public async Task<ActionState> DeleteZoneAsync(int id)
        {
            var actionState = new ActionState();
            var zone = await _unitOfWork.ZonesRepository.FindByIdAsync(id);
            if (zone == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Zone !");
                return actionState;
            }
            _unitOfWork.ZonesRepository.Delete(zone);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Zone");
            return actionState;
        }

        public async Task<ActionState> EditZoneAsync(EditZoneViewModel editZoneViewModel)
        {
            var actionState = new ActionState();
            var zone = _mapper.Map<EditZoneViewModel, Zone>(editZoneViewModel);
            _unitOfWork.ZonesRepository.Update(zone);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Zone");
            return actionState;
        }
        public async Task<ZoneViewModel> GetZoneDetailsAsync(int Id)
        {
            var zone = await _unitOfWork.ZonesRepository.FindElementAsync(zone => zone.Id == Id, nameof(Zone.Stock));

            var zoneViewModel = _mapper.Map<Zone, ZoneViewModel>(zone);

            return zoneViewModel;
        }
        public async Task<PagedResult<ZoneViewModel>> GetDashboardZonesAsync(PagingParameters pagingParameters)
        {
            var zones = await _unitOfWork.ZonesRepository.GetElementsAsync(zone => true, pagingParameters, nameof(Zone.Stock));

            var zonesViewModel = zones.ToMappedPagedResult<Zone, ZoneViewModel>(_mapper);

            return zonesViewModel;
        }
    }
}
