using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TWHelp.API
{
    [Authorize]
    [Route("api/auth/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/auth/test/anonymous
        [AllowAnonymous]
        [HttpGet("anonymous")]
        public IActionResult GetAnonymous()
        {
            return Ok("AllowAnonymous");
        }

        // GET: api/auth/test/token
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            return Ok("JwtBearerDefaults");
        }

        // GET: api/auth/test/identity
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [HttpGet("identity")]
        public IActionResult GetIdentity()
        {
            return Ok("CookieAuthenticationDefaults");
        }

        // GET: api/auth/test/both
        [HttpGet("both")]
        public IActionResult GetBoth()
        {
            return Ok("Both");
        }
    }
}
