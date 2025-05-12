namespace EventSourcing.POC.Data.DataModels 
{
    public class EventData 
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public Guid AggregateId { get; set; }
        public DateTimeOffset EventTimeStamp { get; set; }
        public string EventType { get; set; } = string.Empty;
        
        /// <summary>
        /// Stringyfied JSON representing extra props specific to an event.
        /// </summary>
        public string Data { get; set; } = string.Empty;
    }
}