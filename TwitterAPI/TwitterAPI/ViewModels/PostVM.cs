using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitterAPI.ViewModels
{
    public class PostVM
    {
        [JsonRequired]
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonRequired]
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonRequired]
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("hashtags")]
        public IEnumerable<string> Hasthtags { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("publisher")]
        public string OwnerEmail { get; set; }
    }
}
