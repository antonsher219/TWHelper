using Newtonsoft.Json;

namespace ElasticSearch.ResponseModels
{
    //using for search in elastic
    //to know how this entity maps in elastic see Index_setting.json
    class SearchEntity
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("education")]
        public string Education { get; set; }

        [JsonProperty("expertiseArea")]
        public string ExpertiseArea { get; set; }

        [JsonProperty("activate")]
        public bool IsActivated { get; set; }
    }
}
