using InteractiveWebsite.Common;
using InteractiveWebsite.Common.Interfaces.Authentication;
using InteractiveWebsite.Database;
using InteractiveWebsite.Database.Entities;
using InteractiveWebsite.Services.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace InteractiveWebsite.Core.Services
{
    internal static class AuthenticationServices
    {
        public static IServiceCollection WithAuthenticationServices(this IServiceCollection serviceCollection, IConfiguration configuration, bool isDevelopment)
            => serviceCollection
                .WithIdentityOptions(isDevelopment)
                .WithProviders(configuration)
                .WithIdentity()
                .AddSingleton<IJwtHandler, JwtHandler>()
                .AddScoped<IRegisterHandler, RegisterHandler>()
                .AddScoped<ILoginHandler, LoginHandler>();

        private static IServiceCollection WithIdentityOptions(this IServiceCollection serviceCollection, bool isDevelopment)
            => serviceCollection.Configure<IdentityOptions>(options =>
            {
                if (!isDevelopment)
                    options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                // Change here => change in Angular
                options.Password = new()
                {
                    RequireDigit = false,
                    RequiredLength = 6,
                    RequiredUniqueChars = 1,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false,
                };
                options.Lockout = new()
                {
                    AllowedForNewUsers = true,
                    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                    MaxFailedAccessAttempts = 5
                };
            });


        private static IServiceCollection WithProviders(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration[Constants.JwtValidIssuerConfigIndex],
                        ValidAudience = configuration[Constants.JwtValidAudienceConfigIndex],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Constants.JwtSecurityKeyConfigIndex]))
                    };
                });
            return serviceCollection;
        }

        private static IServiceCollection WithIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return serviceCollection;
        }
    }
}
