using LowCost.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Interfaces.Settings
{
    public interface ISettingsRepository : IGenericRepository<LowCost.Domain.Models.Settings>
    {
        /// <summary>
        /// Get Value From Settings Using Setting Key Asynchronous
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        Task<string> GetSettingValueUsingKeyAsync(string Key);
    }
}
