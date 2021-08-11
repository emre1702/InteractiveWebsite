using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InteractiveWebsite.Filters.LevelRequirement
{
    public class LevelRequirementFilter : IAsyncAuthorizationFilter, IOrderedFilter
    {
        public int Order => int.MinValue;
        public NavigationItem NavigationItem { get; }
        public string ClaimId { get; }
        public string InfoText { get; }

        public LevelRequirementFilter(NavigationItem navigationItem, string claimId, string infoText)
            => (NavigationItem, ClaimId, InfoText) = (navigationItem, claimId, infoText);

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizedService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizedService>();
            return authorizedService.IsAuthorized(context.HttpContext.User, NavigationItem, ClaimId);
        }
    }
}
