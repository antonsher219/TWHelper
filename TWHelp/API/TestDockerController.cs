using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TWHelp.Models.Infrastructure;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDockerController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        public TestDockerController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/TestDocker
        [HttpGet]
        public ActionResult<string> TestWebApi()
        {
            return Ok("get");
        }

        // GET: api/TestDocker/python
        [HttpGet("python")]
        public ActionResult<string> TestPythonModel()
        {
            string link = _configuration["ConnectionStrings:Docker:PythonModel"] + "/test";
            try {
                string response = HttpSender.SendHttpRequest(new Uri(link), "GET");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET: api/TestDocker/elastic
        [HttpGet("elastic")]
        public ActionResult<string> TestElasticsearch()
        {
            string link = _configuration["ConnectionStrings:Docker:Elasticsearch"];
            try
            {
                string response = HttpSender.SendHttpRequest(new Uri(link), "GET");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET: api/TestDocker/database
        [HttpGet("database")]
        public ActionResult<string> TestDatabase()
        {
            try
            {
                bool any = _context.Users.Any();

                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
