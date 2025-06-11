namespace EventSourcing.POC.Domain.Events  
{
    public abstract class Event
    {
        /// <summary>
        /// Use for new events
        /// </summary>
        public Event(Guid aggregrateId, string eventType)
        {
            AggregateId = aggregrateId;
            EventType = eventType;
        }

        //Think abt this
        // public abstract Event Reconstruct(
        //     Guid aggregrateId,
        //     Guid eventId,
        //     DateTimeOffset eventTimeStamp,
        //     string eventType,
        //     params object[] eventData
        // );

        public Guid EventId { get; internal set; } = Guid.NewGuid();
        public Guid AggregateId { get; internal set; }
        public DateTimeOffset EventTimeStamp { get; internal set; } = DateTimeOffset.UtcNow;
        public string EventType { get; internal set; }
    }
}