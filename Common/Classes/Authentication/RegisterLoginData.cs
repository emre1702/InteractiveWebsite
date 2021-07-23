﻿namespace InteractiveWebsite.Common.Classes.Authentication
{
    public class RegisterLoginData
    {
        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
