using InteractiveWebsite.Common.Interfaces.Members;
using InteractiveWebsite.Services.Members;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    public static class MembersServices
    {
        public static IServiceCollection WithMembersServices(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<IMembersDataService, MembersDataService>();
    }
}
