using Newtonsoft.Json;

namespace ElasticSearch.ResponseModels
{
    //using for search in elastic
    //to know how this entity maps in elastic see Index_setting.json
    class SearchEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nicnName")]
        public string NickName { get; set; }

        [JsonProperty("education")]
        public string Education { get; set; }

        [JsonProperty("areaOfExpertise")]
        public string AreaOfExpertise { get; set; }

        [JsonProperty("isAccountActivated")]
        public bool IsAccountActivated { get; set; }
    }
}
