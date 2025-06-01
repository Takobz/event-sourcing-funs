using System.Text.Json.Serialization;

namespace EventSourcing.POC.Data.DataModels 
{
    /// <summary>
    /// JSON data that will be store as a column for the event row.
    /// </summary>
    [JsonDerivedType(typeof(UserCreatedJSONData))]
    public abstract class EventJSONData
    {
        public int Version { get; set; }
    }

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

        public string Username { get; set; }
        public string Email { get; set; }
    }
}