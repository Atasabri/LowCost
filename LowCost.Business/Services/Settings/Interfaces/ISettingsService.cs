using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Settings.Interfaces
{
    public interface ISettingsService
    {
        /// <summary>
        /// Get Taxs From Settings Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<double> GetTaxsAsync();
        /// <summary>
        /// Check Visa is Available Or Not Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<bool> CheckVisaAvailableAsync();
    }
}
