using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InteractiveWebsite.Common.Interfaces.Authorization
{
    public interface IJwtHandler
    {
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
        List<Claim> GetClaims(IdentityUser user);
        SigningCredentials GetSigningCredentials();
    }
}
