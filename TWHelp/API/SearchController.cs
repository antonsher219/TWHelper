using ElasticSearch;
using TWHelp.Models.DTOs;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ElasticSearchClient elasticClient;

        public SearchController(IConfiguration configuration)
        {
            elasticClient = new ElasticSearchClient(
                configuration.GetSection("Settings:ElasticsearchHost").Value,
                configuration.GetSection("Settings:ElasticsearchIndexName").Value);
        }

        //GET: api/search/full/psychologist/{data}
        [HttpGet("full/psychologist/{data}")]
        public ActionResult<string> WholeSearch(string data)
        {
            string response = elasticClient.SearchUserNames(data, 30);

            return Ok(response);
        }

        //GET: api/search/autocomplete/psychologist/{data}
        [HttpGet("autocomplete/psychologist/{data}")]
        public ActionResult<string> Autocomplete(string data)
        {
            string response = elasticClient.AutocompleteDataFromElastic(data);

            return Ok(response);
        }

    }
}