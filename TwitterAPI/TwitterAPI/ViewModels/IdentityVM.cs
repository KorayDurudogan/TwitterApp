using Newtonsoft.Json;

namespace TwitterAPI.ViewModels
{
    public class IdentityVM
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }
    }
}
