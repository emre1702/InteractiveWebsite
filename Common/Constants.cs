using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common
{
    public class Constants
    {
        public const string JwtSecurityKeyConfigIndex = "Authentication:Jwt:SecurityKey";
        public const string JwtValidIssuerConfigIndex = "Authentication:Jwt:ValidIssuer";
        public const string JwtValidAudienceConfigIndex = "Authentication:Jwt:ValidAudience";
        public const string JwtExpiryInMinutesConfigIndex = "Authentication:Jwt:ExpiryInMinutes";

        public static Func<string, string> AuthClientIdConfigIndex { get; } = (schema) => $"Authentication:{schema}:ClientId";
        public static Func<string, string> AuthClientSecretConfigIndex { get; } = (schema) => $"Authentication:{schema}:ClientSecret";
    }
}
