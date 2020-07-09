using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TwitterAPI.ViewModels
{
    /// <summary>
    /// A ViewModel suitable for login, register and token authentication.
    /// </summary>
    public class UserVM
    {
        [JsonRequired]
        [EmailAddress]
        [JsonProperty("email")]
        public string EMail { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
