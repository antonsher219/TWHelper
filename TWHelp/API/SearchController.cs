using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWHelp.Models.DTOs;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        //GET: api/search/psychologist/{data}
        [HttpGet("psychologist/{data}")]
        public async Task<ActionResult<List<PsychologistDTO>>> Search(string data)
        {
            //TODO: not implemented
            return BadRequest();
        }

    }
}