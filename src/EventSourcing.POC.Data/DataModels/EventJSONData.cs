namespace EventSourcing.POC.Data.DataModels 
{
    /// <summary>
    /// JSON data that will be store as a column for the event row.
    /// </summary>
    public class EventJSONData {}
    
    public class UserCreationJSONData : EventJSONData
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}