namespace EventSourcing.POC.Data.DataModels 
{
    /// <summary>
    /// JSON data that will be store as a column for the event row.
    /// </summary>
    public class EventJSONData {}
    
    public class UserCreatedJSONData : EventJSONData
    {
        public UserCreatedJSONData(
            string username,
            string email
        )
        {
            Username = username;
            Email = email;
        }

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}