using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace ElasticSearch
{
    class ElasticIndexProvider
    {
        private string _indexName;
        private string _elasticURL;

        public ElasticIndexProvider(string elasticUrl, string indexName)
        {
            _elasticURL = elasticUrl;
            _indexName = indexName;
        }

        public void CreateElasticIndex()
        {
            try
            {
                var uri = new Uri(_elasticURL + "/" + _indexName);
                string response = CustomHttpSender.SendHttpRequest(uri, "PUT");

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

        //take json file and set it to elastic (creates index/type & apply rules for mapping)
        public void CreateElasticFromIndexSettings()
        {
            string requestBody = ReadElasticSettings(ConfigurationManager.AppSettings["IndexSettingsPath"]);
            var path = new Uri(_elasticURL + "/" + _indexName);

            try
            {
                string response = CustomHttpSender.SendHttpRequest(path, "PUT", requestBody);

                if (response.Contains("\"errors\":true"))
                {
                    Console.WriteLine(response);
                }
                else
                {
                    Console.WriteLine("index created");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //read file by path
        private string ReadElasticSettings(string fileName)
        {
            string requestBody = String.Empty;

            if (File.Exists(fileName))
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    requestBody = r.ReadToEnd();
                }
            }
            else
            {
                string errorMessage = "index_settings.json file not found. specify path to it in App.config file";
                throw new Exception(errorMessage);
            }

            return requestBody;
        }

        public void DeleteElasticIndex()
        {
            try
            {
                string response = CustomHttpSender.SendHttpRequest(new Uri(_elasticURL + "/" + _indexName), "DELETE");

                if (!response.Contains("\"acknowledged\":true"))
                {
                    Console.WriteLine(response);
                }
                else
                {
                    Console.WriteLine("index deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
