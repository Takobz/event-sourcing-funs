
using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events
{
    public class UserUpdatedEvent : Event
    {
        /// <summary>
        /// Use this to reconstruct the event.
        /// </summary>
        public UserUpdatedEvent() : base(Guid.Empty, EventTypes.UserUpdated) { }

        public UserUpdatedEvent(
            Guid aggregrateId,
            string eventType,
            string email
        ) : base(aggregrateId, eventType)
        {
            Email = email;
        }

        public string Email = string.Empty;

        public UserUpdatedEvent Reconstruct(
            Guid aggregateId,
            Guid eventId,
            DateTimeOffset eventTimestamp,
            string eventType,
            string email
        )
        {
            AggregateId = aggregateId;
            EventId = eventId;
            EventTimeStamp = eventTimestamp;
            EventType = eventType;
            Email = email;

            return this;
        }
    }
}