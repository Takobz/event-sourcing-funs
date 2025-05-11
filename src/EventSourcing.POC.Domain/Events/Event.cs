namespace EventSourcing.POC.Domain.Events  
{
    public class Event(
        Guid aggregrateId,
        string eventType
    )
    {
        public Guid EventId { get; private set; } = Guid.NewGuid();
        public Guid AggregateId { get; private set; } = aggregrateId;
        public DateTimeOffset EventTimeStamp { get; private set; } = DateTimeOffset.UtcNow;
        public string EventType { get; private set; } = eventType;
    }
}