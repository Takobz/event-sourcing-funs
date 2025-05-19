namespace EventSourcing.POC.Data.Options
{
    /// <summary>
    /// Use with postgres image
    /// </summary>
    public class EventSourcingPOCPostgresDataOptions
    {
        public const string SectionName = "EventSourcingPOCDataOptions";

        public string Host { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; } = 5432;
    }
}
