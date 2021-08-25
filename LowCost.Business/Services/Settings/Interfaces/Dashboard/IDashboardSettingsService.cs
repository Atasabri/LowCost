using LowCost.Infrastructure.DashboardViewModels.Settings;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Settings.Interfaces.Dashboard
{
    public interface IDashboardSettingsService
    {
        /// <summary>
        /// Get All Settings Keys & Values Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<EditSettingsViewModel> GetSettingsForEditAsync();
        /// <summary>
        /// Edit Settings Values Asynchronous
        /// </summary>
        /// <param name="editSettingsViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditSettingsValuesAsync(EditSettingsViewModel editSettingsViewModel);
    }
}
