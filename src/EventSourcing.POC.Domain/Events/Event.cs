namespace EventSourcing.POC.Domain.Events  
{
    public class Event
    {
        /// <summary>
        /// Use for new events
        /// </summary>
        public Event(Guid aggregrateId, string eventType)
        {
            AggregateId = aggregrateId;
            EventType = eventType;
        }

        /// <summary>
        /// Use this when reading events so we can read all the data
        /// </summary>
        public void Reconstruct(
            Guid aggregrateId,
            Guid eventId,
            DateTimeOffset eventTimeStamp,
            string eventType
        )
        {
            AggregateId = aggregrateId;
            EventId = eventId;
            EventTimeStamp = eventTimeStamp;
            EventType = eventType;
        }

        public Guid EventId { get; internal set; } = Guid.NewGuid();
        public Guid AggregateId { get; internal set; }
        public DateTimeOffset EventTimeStamp { get; internal set; } = DateTimeOffset.UtcNow;
        public string EventType { get; internal set; }
    }
}