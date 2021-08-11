using InteractiveWebsite.Common.WebModels.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Authorization
{
    public interface ILoginHandler
    {
        Task<LoginResult> LoginInternal(RegisterLoginData data);
        Task<LoginResult> LoginInternal(string email, bool isPersistent);
        Task<LoginResult?> CheckIsLoggedIn(ClaimsPrincipal claimsPrincipal);
        Task Logout(ClaimsPrincipal claimsPrincipal);
    }
}
