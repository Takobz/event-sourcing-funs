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
        public Event(
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

        public Guid EventId { get; private set; } = Guid.NewGuid();
        public Guid AggregateId { get; private set; }
        public DateTimeOffset EventTimeStamp { get; private set; } = DateTimeOffset.UtcNow;
        public string EventType { get; private set; }
    }
}