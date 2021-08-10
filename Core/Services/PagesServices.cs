using InteractiveWebsite.Common.Interfaces.Pages;
using InteractiveWebsite.Services.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    public static class PagesServices
    {
        public static IServiceCollection WithPagesServices(this IServiceCollection serviceCollection)
            => serviceCollection.AddScoped<INavigationService, NavigationService>();
    }
}
