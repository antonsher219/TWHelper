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
            List<string> bulkUploads = new List<string>();
            StringBuilder bulk = new StringBuilder(100000);

            /*
             * Should look like this (for animal):
             * 
             * { "create" : { "_index" : "zoo", "_type" : "animal", "_id" : "1" } }
             * { "name" : "White Fang", "kind" : "Wolf", "age": 3 }
             */

            for(int i = 0; i < entities.Count; i += 1)
            {
                bulk.Append("{\"create\":{\"_index\":\"psychologists\",\"_type\":\"psychologist\",\"_id\":\"" + i + "\"}}\n");
                bulk.Append($"{{\"id\":\"{entities[i].Id}\",\"nickName\":\"{entities[i].NickName}\",\"education\":\"{entities[i].Education}\",\"areaOfExpertise\":\"{entities[i].AreaOfExpertise}\",\"isAccountActivated\": \"{entities[i].IsAccountActivated}\"}}\n");
                
                if(i % 1000 == 0)
                {
                    bulkUploads.Add(bulk.ToString());
                    bulk.Clear();
                }
            }

            if(bulk.Length != 0)
            {
                bulkUploads.Add(bulk.ToString());
                bulk.Clear();
            }

            var uri = new Uri(_elasticURL + "/_bulk");

            for(int i = 0; i < bulkUploads.Count; i++) 
            {
                try
                {

                    string response = CustomHttpSender.SendHttpRequest(uri, "POST", bulkUploads[i]);

                    if (response.Contains("\"errors\":true"))
                    {
                        Console.WriteLine("data upload warning");
                    }
                    else
                    {
                        Console.WriteLine($"data uploaded {i + 1} out of {bulkUploads.Count}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

