using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Zoons.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Zoons;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zoons.Implementation.Dashboard
{
    public class DashboardZoonsService : IDashboardZoonsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardZoonsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateZoonAsync(AddZoonViewModel addZoonViewModel)
        {
            var createState = new CreateState();
            var zoon = _mapper.Map<AddZoonViewModel, Zoon>(addZoonViewModel);

            await _unitOfWork.ZoonsRepository.CreateAsync(zoon);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Zoon");
            return createState;
        }

        public async Task<ActionState> DeleteZoonAsync(int id)
        {
            var actionState = new ActionState();
            var zoon = await _unitOfWork.ZoonsRepository.FindByIdAsync(id);
            if (zoon == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Zoon !");
                return actionState;
            }
            _unitOfWork.ZoonsRepository.Delete(zoon);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Zoon");
            return actionState;
        }

        public async Task<ActionState> EditZoonAsync(EditZoonViewModel editZoonViewModel)
        {
            var actionState = new ActionState();
            var zoon = _mapper.Map<EditZoonViewModel, Zoon>(editZoonViewModel);
            _unitOfWork.ZoonsRepository.Update(zoon);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Zoon");
            return actionState;
        }
        public async Task<ZoonViewModel> GetZoonDetailsAsync(int Id)
        {
            var zoon = await _unitOfWork.ZoonsRepository.FindElementAsync(zoon => zoon.Id == Id, nameof(Zoon.Stock));

            var zoonViewModel = _mapper.Map<Zoon, ZoonViewModel>(zoon);

            return zoonViewModel;
        }
        public async Task<PagedResult<ZoonViewModel>> GetDashboardZoonsAsync(PagingParameters pagingParameters)
        {
            var zoons = await _unitOfWork.ZoonsRepository.GetElementsAsync(zoon => true, pagingParameters, nameof(Zoon.Stock));

            var zoonsViewModel = zoons.ToMappedPagedResult<Zoon, ZoonViewModel>(_mapper);

            return zoonsViewModel;
        }
    }
}
