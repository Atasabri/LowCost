using LowCost.Domain.Context;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Implementation.Settings
{
    public class SettingsRepository : GenericRepository<LowCost.Domain.Models.Settings>, ISettingsRepository
    {
        public SettingsRepository(DB context)
        : base(context)
        {
        }

        public async Task<string> GetSettingValueUsingKeyAsync(string Key)
        {
            return (await FindElementAsync(setting => setting.Key == Key))?.Value;
        }
    }
}
