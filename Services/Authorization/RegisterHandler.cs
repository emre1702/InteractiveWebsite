using InteractiveWebsite.Common.Interfaces.Authorization;
using InteractiveWebsite.Common.WebModels.Authentication;
using InteractiveWebsite.Database.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Authorization
{
    public class RegisterHandler : IRegisterHandler
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> RegisterInternal(RegisterLoginData data)
        {
            var user = new AppUser { UserName = data.Email, Email = data.Email, EmailConfirmed = false };
            var result = data.Password is null ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, data.Password);

            //Todo: Handle Email confirmation - if not needed, sign in

            return new(result.Succeeded, result.Errors?.Select(e => e.Description), user);
        }
    }
}