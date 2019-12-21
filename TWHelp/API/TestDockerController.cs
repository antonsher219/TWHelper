using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDockerController : ControllerBase
    {
        // GET: api/TestDocker
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("get");
        }
    }
}
