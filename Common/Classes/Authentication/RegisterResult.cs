using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InteractiveWebsite.Common.Classes.Authentication
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        [JsonIgnore]
        public IdentityUser User { get; set; }

        public RegisterResult(bool succeeded, IEnumerable<string>? errors, IdentityUser user)
        {
            Succeeded = succeeded;
            Errors = errors;
            User = user;
        }
    }
}
