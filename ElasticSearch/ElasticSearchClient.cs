using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    public class ElasticSearchClient
    {
        private string _indexName;
        private string _elasticURL;

        public ElasticSearchClient(string elasticUrl, string indexName)
        {
            _elasticURL = elasticUrl;
            _indexName = indexName;
        }

        //simple search
        public string SearchUserNames(string userSearch, int numberOfResult)
        {
            string requestUrl = string.Format("{0}/{1}/_search/?size={2}", _elasticURL, _indexName, numberOfResult);
            string requestBody = "{\"query\":{\"match\":{\"nickName\": \" " + userSearch + " \"}}}";

            try
            {
                return CustomHttpSender.SendHttpRequest(new Uri(requestUrl), "POST", requestBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return string.Empty;
        }

        //query data from whole elastic
        public string AutocompleteDataFromElastic(string userSearch)
        {
            string requestUrl = string.Format("{0}/_msearch", _elasticURL);
            string requestBody = "{\"index\": \"user_data\"}\n{\"size\":10,\"query\":{\"bool\":{\"filter\":[{\"terms\":{\"customerId\":[7]}}],\"must\":[{\"match_phrase_prefix\":{\"userName\":\""+ userSearch + "\"}}]}}}\n";

            try
            {
                return CustomHttpSender.SendHttpRequest(new Uri(requestUrl), "POST", requestBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return string.Empty;
        }
    }
}
