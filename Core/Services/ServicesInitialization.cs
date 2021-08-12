using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    internal static class ServicesInitialization
    {
        public static IServiceCollection WithAppServices(this IServiceCollection serviceCollection, IConfiguration configuration, bool isDevelopment)
            => serviceCollection
                .WithAuthorizationServices(configuration, isDevelopment)
                .WithInformationServices()
                .WithPagesServices()
                .WithSettingsServices()
                .WithMembersServices();
    }
}
