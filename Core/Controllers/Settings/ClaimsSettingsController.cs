using InteractiveWebsite.Common.Interfaces.Settings;
using InteractiveWebsite.Common.WebModels.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteractiveWebsite.Core.Controllers.Settings
{
    public class ClaimsSettingsController : CustomControllerBase
    {
        private readonly IClaimsSettingsService _claimsSettingsService;

        public ClaimsSettingsController(IClaimsSettingsService claimsSettingsService)
            => _claimsSettingsService = claimsSettingsService;

        [HttpGet]
        public IAsyncEnumerable<ClaimsSettingsWebConfiguration> LoadClaimsSettings()
            => _claimsSettingsService.GetClaimsSettingsWebConfigurations();

        [HttpPost]
        public async IAsyncEnumerable<ClaimsSettingsWebConfiguration> SaveClaimsSettings(IEnumerable<ClaimsSettingsWebConfiguration> changedWebConfigurations) 
        {
            await _claimsSettingsService.SaveClaimsSettings(changedWebConfigurations);
            await foreach (var webConfig in _claimsSettingsService.GetClaimsSettingsWebConfigurations())
                yield return webConfig;
        }
    }
}
