using System;

namespace InteractiveWebsite.Common
{
    public static class Constants
    {
        public const string JwtSecurityKeyConfigIndex = "Authentication:Jwt:SecurityKey";
        public const string JwtValidIssuerConfigIndex = "Authentication:Jwt:ValidIssuer";
        public const string JwtValidAudienceConfigIndex = "Authentication:Jwt:ValidAudience";
        public const string JwtExpiryInMinutesConfigIndex = "Authentication:Jwt:ExpiryInMinutes";

        public static Func<string, string> AuthClientIdConfigIndex { get; } = (schema) => $"Authentication:{schema}:ClientId";
        public static Func<string, string> AuthClientSecretConfigIndex { get; } = (schema) => $"Authentication:{schema}:ClientSecret";

        public const int MaxNewsPerPage = 10;
        public const int MaxMembersPerPage = 10;
    }
}
