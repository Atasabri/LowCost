using LowCost.Business.Services.Settings.Interfaces.Dashboard;
using LowCost.Infrastructure.AppSettings;
using LowCost.Infrastructure.DashboardViewModels.Settings;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class SettingsController : Controller
    {
        private readonly IDashboardSettingsService _settingsService;

        public SettingsController(IDashboardSettingsService settingsService)
        {
            this._settingsService = settingsService;
        }

        public async Task<IActionResult> EditSettings()
        {
            var result = await _settingsService.GetSettingsForEditAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditSettings(EditSettingsViewModel editSettingsViewModel)
        {
            var result = await _settingsService.EditSettingsValuesAsync(editSettingsViewModel);
            var model = await _settingsService.GetSettingsForEditAsync();
            if (!result.ExcuteSuccessfully)
            {
                ViewBag.Error = result.ErrorMessages.FirstOrDefault();
                return View(model);
            }
            ViewBag.Done = "Settings Updated Done.";
            return View(model);
        }
    }
}
