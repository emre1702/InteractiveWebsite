using InteractiveWebsite.Common.Classes.Authentication;
using InteractiveWebsite.Common.Entities.Authentication;
using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Authorization
{
    public class LoginHandler : ILoginHandler
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtHandler _jwtHandler;

        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtHandler jwtHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<LoginResult> LoginInternal(RegisterLoginData data)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(data.Email, data.Password, data.RememberMe, true);

            if (signInResult.IsLockedOut) return new(LoginResultStatus.Lockout);
            if (signInResult.IsNotAllowed) return new(LoginResultStatus.NotAllowed);
            if (signInResult.RequiresTwoFactor) return new(LoginResultStatus.RequiresTwoFactor);

            var user = await _userManager.FindByEmailAsync(data.Email)!;
            return new(LoginResultStatus.Succeeded) { Token = GetToken(user) };
        }

        public async Task<LoginResult> LoginInternal(string email, bool isPersistent)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _signInManager.SignInAsync(user, isPersistent);

            return new(LoginResultStatus.Succeeded) { Token = GetToken(user) };
        }

        public async Task<LoginResult?> CheckIsLoggedIn(ClaimsPrincipal claimsPrincipal)
        {
            if (!_signInManager.IsSignedIn(claimsPrincipal)) return new(LoginResultStatus.NotAllowed);

            var user = await _userManager.GetUserAsync(claimsPrincipal);
            return new(LoginResultStatus.Succeeded) { Token = GetToken(user) };
        }

        private string GetToken(AppUser user)
        {
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}