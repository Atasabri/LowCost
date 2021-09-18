using LowCost.Business.Services.Settings.Interfaces;
using LowCost.Infrastructure.BaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class SettingsController : APIController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            this._settingsService = settingsService;
        }

        [HttpGet("GetDelivery")]
        public async Task<IActionResult> GetDelivery()
        {
            return Ok(await _settingsService.GetDeliveryAsync());
        }

        [HttpGet("CheckVisaAvailable")]
        public async Task<IActionResult> CheckVisaAvailable()
        {
            return Ok(await _settingsService.CheckVisaAvailableAsync());
        }
    }
}
