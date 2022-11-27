using Newtonsoft.Json;

namespace Tests.API.Models
{
    public class TokenModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }    
    }
}
