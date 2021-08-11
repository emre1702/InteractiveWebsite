using InteractiveWebsite.Common.WebModels.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Settings
{
    public interface IClaimsSettingsService
    {
        IAsyncEnumerable<ClaimsSettingsWebConfiguration> GetClaimsSettingsWebConfigurations();
        Task SaveClaimsSettings(IEnumerable<ClaimsSettingsWebConfiguration> changedWebConfigurations);
    }
}