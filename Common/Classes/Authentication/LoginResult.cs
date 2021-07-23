using InteractiveWebsite.Common.Enums;

namespace InteractiveWebsite.Common.Classes.Authentication
{
    public class LoginResult
    {
        public LoginResultStatus Status { get; set; }
        public string? Token { get; set; }

        public LoginResult(LoginResultStatus result)
        {
            Status = result;
        }
    }
}
