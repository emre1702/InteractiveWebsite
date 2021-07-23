using InteractiveWebsite.Common.Classes.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Authentication
{
    public interface ILoginHandler
    {
        Task<LoginResult> LoginInternal(RegisterLoginData data);
        Task<LoginResult> LoginInternal(string email, bool isPersistent);
        Task<LoginResult?> CheckIsLoggedIn(ClaimsPrincipal claimsPrincipal);
    }
}
