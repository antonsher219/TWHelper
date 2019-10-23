using ElasticSearch.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class ElasticDataProvider
    {
        private string _elasticURL;
        private string _indexName;

        public ElasticDataProvider(string elasticUrl, string indexName)
        {
            _elasticURL = elasticUrl;
            _indexName = indexName;
        }

        //creates new type (table) in elastic
        public void CreateNewType(string typeName, string typeBody)
        {
            var path = new Uri(_elasticURL + "/" + _indexName + "/_mapping/" + typeName);

            try
            {
                string response = CustomHttpSender.SendHttpRequest(path, "PUT", typeBody);

                if (!response.Contains("\"acknowledged\":true"))
                {
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteExistingType(string typeName)
        {
            var path = new Uri(_elasticURL + "/" + _indexName + "/" + typeName);

            try
            {
                string response = CustomHttpSender.SendHttpRequest(path, "DELETE");

                if (!response.Contains("\"acknowledged\":true"))
                {
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UploadDataToElastic(List<SearchEntity> entities)
        {
            string bulkUpload = string.Empty;

            /*
             * Should look like this (for animal):
             * 
             * { "create" : { "_index" : "zoo", "_type" : "animal", "_id" : "1" } }
             * { "name" : "White Fang", "kind" : "Wolf", "age": 3 }
             */

            for(int i = 0; i < entities.Count; i += 1)
            {
                bulkUpload += "{\"create\":{\"_index\":\"psychologists\",\"_type\":\"psychologist\",\"_id\":\"" + i + "\"}}\n";
                bulkUpload += $"{{\"userId\":\"{entities[i].UserId}\",\"userName\":\"{entities[i].UserName}\",\"education\":\"{entities[i].Education}\",\"expertiseArea\":\"{entities[i].ExpertiseArea}\",\"activate\": \"{entities[i].IsActivated}\"}}\n";
            }

            var uri = new Uri(_elasticURL + "/_bulk");
            
            try
            {

                string response = CustomHttpSender.SendHttpRequest(uri, "POST", bulkUpload);

                if (response.Contains("\"errors\":true"))
                {
                    Console.WriteLine("data upload warning");
                }
                else
                {
                    Console.WriteLine("data uploaded");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

