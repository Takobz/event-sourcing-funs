using System.Text.Json.Serialization;

namespace EventSourcing.POC.Data.DataModels 
{
    /// <summary>
    /// JSON data that will be store as a column for the event row.
    /// </summary>
    [JsonDerivedType(typeof(UserCreatedJSONData))]
    [JsonDerivedType(typeof(CartCreatedJSONData))]
    public abstract class EventJSONData
    {
        public int Version { get; set; }
    }
    
}