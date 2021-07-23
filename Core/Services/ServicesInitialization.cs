﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveWebsite.Core.Services
{
    internal static class ServicesInitialization
    {
        public static void WithAppServices(this IServiceCollection serviceCollection, IConfiguration configuration, bool isDevelopment)
            => serviceCollection.WithAuthenticationServices(configuration, isDevelopment);
    }
}