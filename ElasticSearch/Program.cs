using ElasticSearch.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElasticSearch
{
    class Program
    {
        private static string _elasticURL = "http://localhost:9200";
        private static string _indexName = "psychologists";

        static void Main(string[] args)
        {
            RebuildIndex();
        }

        private static void RebuildIndex()
        {
            List<SearchEntity> data = DonwloadData();

            ElasticIndexProvider indexProvider = new ElasticIndexProvider(_elasticURL, _indexName);
            indexProvider.DeleteElasticIndex();
            indexProvider.CreateElasticFromIndexSettings();

            ElasticDataProvider dataProvider = new ElasticDataProvider(_elasticURL, _indexName);
            dataProvider.UploadDataToElastic(data);
        }

        private static List<SearchEntity> DonwloadData()
        {
            List<SearchEntity> entities = new List<SearchEntity>();

            string sql = "select * from AspNetUsers where IsPsychologist = 1";
            string connection = "Server=(localdb)\\mssqllocaldb;Database=aspnet-TWHelp-198A0B6F-A6C5-4A0B-AE3E-A656C11BFDD5;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            using(SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    SearchEntity entity = new SearchEntity()
                    {
                        UserId = long.Parse(reader["Id"].ToString()),
                        UserName = reader["UserName"].ToString(),
                        Education = reader["Education"].ToString(),
                        ExpertiseArea = reader["AreaOfExpertise"].ToString(),
                        IsActivated = bool.Parse(reader["IsAccountActivated"].ToString())
                    };

                    entities.Add(entity);
                }
            }

            return entities;
        }
    }
}
