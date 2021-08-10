using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Authorization;
using InteractiveWebsite.Common.Interfaces.Pages;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace InteractiveWebsite.Services.Pages
{
    public class NavigationService : INavigationService
    {
        private readonly IAuthorizedService _authorizedService;

        public NavigationService(IAuthorizedService authorizedService)
            => _authorizedService = authorizedService;

        public async IAsyncEnumerable<string> GetNavigations(ClaimsPrincipal user)
        {
            var navigations = Enum.GetValues<NavigationItem>();
            foreach (var navigation in navigations)
            {
                var navigationName = Enum.GetName(navigation)!;
                if (await _authorizedService.IsAuthorized(user, navigationName))
                    yield return navigationName;
            }
        }
    }
}
