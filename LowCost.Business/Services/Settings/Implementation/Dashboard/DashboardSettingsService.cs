using AutoMapper;
using LowCost.Business.Services.Settings.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Settings;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Settings.Implementation.Dashboard
{
    public class DashboardSettingsService : IDashboardSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardSettingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<ActionState> EditSettingsValuesAsync(EditSettingsViewModel editSettingsViewModel)
        {
            var actionState = new ActionState();
            foreach (var item in editSettingsViewModel.Settings)
            {
                var setting = await _unitOfWork.SettingsRepository.FindByIdAsync(item.Id);
                setting.Value = item.Value;
                _unitOfWork.SettingsRepository.Update(setting);
            }
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Cahnge Seetings");
            return actionState;
        }

        public async Task<EditSettingsViewModel> GetSettingsForEditAsync()
        {
            var settings = await _unitOfWork.SettingsRepository.GetElementsAsync(setting => true);
            
            var editSettingsViewModel = new EditSettingsViewModel()
            {
                Settings = _mapper.Map<List<Domain.Models.Settings>, List<SettingsKeyValueViewModel>>(settings.ToList())
            };

            return editSettingsViewModel;
        }
    }
}
