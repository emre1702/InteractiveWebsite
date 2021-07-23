using InteractiveWebsite.Common.Entities.Authentication;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InteractiveWebsite.Common.Classes.Authentication
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        [JsonIgnore]
        public AppUser User { get; set; }

        public RegisterResult(bool succeeded, IEnumerable<string>? errors, AppUser user)
        {
            Succeeded = succeeded;
            Errors = errors;
            User = user;
        }
    }
}
