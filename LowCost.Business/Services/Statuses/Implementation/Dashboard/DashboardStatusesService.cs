using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Statuses.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Statuses;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models = LowCost.Domain.Models;

namespace LowCost.Business.Services.Statuses.Implementation.Dashboard
{
    public class DashboardStatusesService : IDashboardStatusesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardStatusesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateStatusAsync(AddStatusViewModel addStatusViewModel)
        {
            var createState = new CreateState();
            var status = _mapper.Map<AddStatusViewModel, Models.Statuses>(addStatusViewModel);

            await _unitOfWork.StatusesRepository.CreateAsync(status);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Status");
            return createState;
        }

        public async Task<ActionState> DeleteStatusAsync(int id)
        {
            var actionState = new ActionState();
            var status = await _unitOfWork.StatusesRepository.FindByIdAsync(id);
            if (status == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Status !");
                return actionState;
            }
            _unitOfWork.StatusesRepository.Delete(status);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Status");
            return actionState;
        }

        public async Task<ActionState> EditStatusAsync(EditStatusViewModel editStatusViewModel)
        {
            var actionState = new ActionState();
            var status = _mapper.Map<EditStatusViewModel, Models.Statuses>(editStatusViewModel);
            _unitOfWork.StatusesRepository.Update(status);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Status");
            return actionState;
        }

        public async Task<IEnumerable<StatusViewModel>> GetAllStatusesAsync()
        {
            var statuses = await _unitOfWork.StatusesRepository.GetElementsAsync(Status => true);

            var statusesViewModel = _mapper.Map<IEnumerable<Models.Statuses>, IEnumerable<StatusViewModel>>(statuses);

            return statusesViewModel;
        }

        public async Task<StatusViewModel> GetStatusDetailsAsync(int Id)
        {
            var status = await _unitOfWork.StatusesRepository.FindByIdAsync(Id);

            var statusViewModel = _mapper.Map<Models.Statuses, StatusViewModel>(status);

            return statusViewModel;
        }

        public async Task<PagedResult<StatusViewModel>> GetDashboardStatusesAsync(PagingParameters pagingParameters)
        {
            var statuses = await _unitOfWork.StatusesRepository.GetElementsWithOrderAsync(Status => true,
                       pagingParameters, Status => Status.Id, OrderingType.Descending);

            var statusesViewModel = statuses.ToMappedPagedResult<Models.Statuses, StatusViewModel>(_mapper);

            return statusesViewModel;
        }
    }
}
