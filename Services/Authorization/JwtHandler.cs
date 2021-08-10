using InteractiveWebsite.Common;
using InteractiveWebsite.Common.Interfaces.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InteractiveWebsite.Services.Authorization
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration _configuration;

        public JwtHandler(IConfiguration configuration)
            => _configuration = configuration;

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration[Constants.JwtSecurityKeyConfigIndex]);
            var secret = new SymmetricSecurityKey(key);
            return new(secret, SecurityAlgorithms.HmacSha256);
        }
        public List<Claim> GetClaims(IdentityUser user)
            => new()
            {
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Email, user.Email)
            };

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
            => new(
                issuer: _configuration[Constants.JwtValidIssuerConfigIndex],
                audience: _configuration[Constants.JwtValidAudienceConfigIndex],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration[Constants.JwtExpiryInMinutesConfigIndex])),
                signingCredentials: signingCredentials);
    }
}