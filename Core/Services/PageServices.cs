using InteractiveWebsite.Common.Interfaces.Information;
using InteractiveWebsite.Services.Information;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    internal static class InformationServices
    {
        public static IServiceCollection WithInformationServices(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<INewsService, NewsService>();
    }
}
