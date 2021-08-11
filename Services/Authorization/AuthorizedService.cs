using InteractiveWebsite.Common;
using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Authorization;
using InteractiveWebsite.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Authorization
{
    public class AuthorizedService : IAuthorizedService
    {
        private readonly AppDbContext _dbContext;

        public AuthorizedService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public bool IsAuthorized(ClaimsPrincipal user, NavigationItem navigationItem, int requiredLevel)
            => HasClaimWithLevelAtleast(user, navigationItem, requiredLevel) || IsHighestAdmin(user);

        private bool HasClaimWithLevelAtleast(ClaimsPrincipal user, NavigationItem navigationItem, int levelAtleast)
        {
            if (levelAtleast <= 0) return true; 
            return user.HasClaim(claim => claim.Type == Enum.GetName(navigationItem) && int.TryParse(claim.Value, out var level) && level >= levelAtleast);
        }

        public bool IsHighestAdmin(ClaimsPrincipal user)
            => HasClaimWithLevelAtleast(user, NavigationItem.Home, int.MaxValue);

        public async Task<bool> IsAuthorized(ClaimsPrincipal user, NavigationItem navigationItem, string claimId)
        {
            var claimSettings = await _dbContext.ClaimsSettings.FirstOrDefaultAsync(claimSettings => claimSettings.Id == claimId && claimSettings.Navigation == navigationItem);
            return IsAuthorized(user, navigationItem, claimSettings?.MinLevel ?? int.MaxValue);
        }
    }
}
