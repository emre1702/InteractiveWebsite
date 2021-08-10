using InteractiveWebsite.Common.Interfaces.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InteractiveWebsite.Core.Filters.LevelRequirement
{
    public class LevelRequirementFilter : IAsyncAuthorizationFilter, IOrderedFilter
    {
        public int Order => int.MinValue;
        public string ClaimId { get; }
        public string InfoText { get; }

        public LevelRequirementFilter(string claimId, string infoText)
            => (ClaimId, InfoText) = (claimId, infoText);

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizedService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizedService>();
            return authorizedService.IsAuthorized(context.HttpContext.User, ClaimId);
        }
    }
}
