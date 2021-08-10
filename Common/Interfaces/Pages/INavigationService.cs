using System.Collections.Generic;
using System.Security.Claims;

namespace InteractiveWebsite.Common.Interfaces.Pages
{
    public interface INavigationService
    {
        IAsyncEnumerable<string> GetNavigations(ClaimsPrincipal user);
    }
}