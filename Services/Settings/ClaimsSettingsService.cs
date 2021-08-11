using InteractiveWebsite.Common.Interfaces.Settings;
using InteractiveWebsite.Common.WebModels.Settings;
using InteractiveWebsite.Database;
using InteractiveWebsite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Settings
{
    public class ClaimsSettingsService : IClaimsSettingsService
    {
        private static readonly SemaphoreSlim _lockSemaphore = new(1);

        private readonly AppDbContext _dbContext;
        private readonly IPossibleClaimsSettingsStorage _possibleClaimsSettingsStorage;

        public ClaimsSettingsService(AppDbContext dbContext, IPossibleClaimsSettingsStorage possibleClaimsSettingsStorage)
            => (_dbContext, _possibleClaimsSettingsStorage) = (dbContext, possibleClaimsSettingsStorage);

        public async IAsyncEnumerable<ClaimsSettingsWebConfiguration> GetClaimsSettingsWebConfigurations()
        {
            await _lockSemaphore.WaitAsync();

            try
            {
                var claimsSettings = await _dbContext.ClaimsSettings.ToListAsync();

                foreach (var possibleClaimsSettingsWithoutValues in _possibleClaimsSettingsStorage.ClaimsSettingsWithoutValues)
                {
                    var claimSettings = claimsSettings.FirstOrDefault(s => s.Id == possibleClaimsSettingsWithoutValues.ClaimId && s.Navigation == possibleClaimsSettingsWithoutValues.Navigation);
                    var webConfig = new ClaimsSettingsWebConfiguration(
                        possibleClaimsSettingsWithoutValues.ClaimId,
                        possibleClaimsSettingsWithoutValues.Navigation,
                        possibleClaimsSettingsWithoutValues.Info,
                        claimSettings?.MinLevel ?? int.MaxValue);
                    yield return webConfig;
                }
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }

        public async Task SaveClaimsSettings(IEnumerable<ClaimsSettingsWebConfiguration> changedWebConfigurations)
        {
            await _lockSemaphore.WaitAsync();

            try
            {
                foreach (var webConfiguration in changedWebConfigurations)
                {
                    var claimSettings = await _dbContext.ClaimsSettings.FirstOrDefaultAsync(s => s.Id == webConfiguration.ClaimId && s.Navigation == webConfiguration.Navigation);
                    if (claimSettings is not null) claimSettings.MinLevel = webConfiguration.MinLevel;
                    else CreateNewEntry(webConfiguration);
                }
                await _dbContext.SaveChangesAsync();
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }

        private ClaimsSettings CreateNewEntry(ClaimsSettingsWebConfiguration webConfiguration)
        {
            var claimSettings = new ClaimsSettings { Id = webConfiguration.ClaimId, Navigation = webConfiguration.Navigation, MinLevel = webConfiguration.MinLevel };
            _dbContext.ClaimsSettings.Add(claimSettings);
            return claimSettings;
        }
    }
}
