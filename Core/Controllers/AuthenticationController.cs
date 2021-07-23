﻿using InteractiveWebsite.Common.Classes.Authentication;
using InteractiveWebsite.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InteractiveWebsite.Core.Controllers
{
    public class AuthenticationController
    {
        [Route("{language}/[controller]")]
        public class AccountController : Controller
        {
            private readonly IRegisterHandler _registerHandler;
            private readonly ILoginHandler _loginHandler;

            public AccountController(IRegisterHandler registerHandler, ILoginHandler loginHandler)
            {
                _registerHandler = registerHandler;
                _loginHandler = loginHandler;
            }

            [AllowAnonymous]
            [HttpPost("Register")]
            public async Task<IActionResult> Register([FromBody] RegisterLoginData data)
            {
                var result = await _registerHandler.RegisterInternal(data);
                return Ok(result);
            }

            [AllowAnonymous]
            [HttpPost("Login")]
            public async Task<IActionResult> Login([FromBody] RegisterLoginData data)
            {
                var result = await _loginHandler.LoginInternal(data);
                return Ok(result);
            }

            [AllowAnonymous]
            [HttpGet("CheckIsLoggedIn")]
            public async Task<IActionResult> CheckIsLoggedIn()
            {
                var result = await _loginHandler.CheckIsLoggedIn(User);
                return Ok(result);
            }
        }
    }
}
