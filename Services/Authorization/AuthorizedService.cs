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

        public bool IsAuthorized(ClaimsPrincipal user, string claimId, int requiredLevel)
            => HasClaimWithLevelAtleast(user, claimId, requiredLevel) || IsHighestAdmin(user);

        private bool HasClaimWithLevelAtleast(ClaimsPrincipal user, string claimId, int levelAtleast)
        {
            if (levelAtleast <= 0) return true; 
            return user.HasClaim(claim => claim.Type == claimId && int.TryParse(claim.Value, out var level) && level >= levelAtleast);
        }

        public bool IsHighestAdmin(ClaimsPrincipal user)
            => HasClaimWithLevelAtleast(user, Constants.AdminClaimId.ToString(), int.MaxValue);

        public async Task<bool> IsAuthorized(ClaimsPrincipal user, string claimId)
        {
            var claimSetting = await _dbContext.ClaimsSettings.FirstOrDefaultAsync(claimSettings => claimSettings.Id == claimId);
            return IsAuthorized(user, claimId, claimSetting?.MinLevel ?? int.MaxValue);
        }
    }
}
