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
    public class PredictionModelController : ControllerBase
    {
        [HttpGet]
        public async Task<string> GetPredictionRequest(int id)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task CreateRequestForPrediction()
        {
            throw new NotImplementedException();
        }
    }
}