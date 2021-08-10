using InteractiveWebsite.Common.Enums;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Authorization
{
    public interface IAuthorizedService
    {
        bool IsAuthorized(ClaimsPrincipal user, string claimId, int requiredLevel);
        bool IsHighestAdmin(ClaimsPrincipal user);
        Task<bool> IsAuthorized(ClaimsPrincipal user, string claimId);
    }
}
