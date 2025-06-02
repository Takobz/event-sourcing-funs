using System.Text.Json.Serialization;

namespace EventSourcing.POC.Data.DataModels
{
    public class UserCreatedJSONData : EventJSONData
    {
        public UserCreatedJSONData(
            string username,
            string email,
            int version = 1
        )
        {
            Username = username;
            Email = email;
            Version = version;
        }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }    
}