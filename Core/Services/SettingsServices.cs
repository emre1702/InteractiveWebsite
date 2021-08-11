using InteractiveWebsite.Common.Interfaces.Settings;
using InteractiveWebsite.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    internal static class SettingsServices
    {
        public static IServiceCollection WithSettingsServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<IPossibleClaimsSettingsStorage, PossibleClaimsSettingsStorage>()
                .AddScoped<IClaimsSettingsService, ClaimsSettingsService>();
    }
}
