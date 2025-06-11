using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{    /// <summary>
     /// User creation event. Should have all props I need to create a user.
     /// </summary>
     /// <param name="aggregateId"></param>
    public class UserCreatedEvent : Event
    {
        /// <summary>
        /// User this constructor to create a new UserCreatedEvent
        /// </summary>
        public UserCreatedEvent(
            Guid aggregateId,
            string username,
            string email) : base(aggregateId, EventTypes.UserCreated)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; internal set; }
        public string Email { get; internal set; }

        /// <summary>
        /// Only use this constructor for reconstruct i.e: new UserCreatedEvent().Reconstruct([...])
        /// </summary>
#pragma warning disable CS8618
        public UserCreatedEvent() : base(Guid.NewGuid(), EventTypes.UserCreated) { }
#pragma warning restore CS8618

        public UserCreatedEvent Reconstruct(
            Guid aggregateId,
            Guid eventId,
            string username,
            string email,
            DateTimeOffset eventTimeStamp
        )
        {
            AggregateId = aggregateId;
            EventId = eventId;
            Username = username;
            Email = email;
            EventTimeStamp = eventTimeStamp;
            EventType = EventTypes.UserCreated;

            return this;
        }
    }
}