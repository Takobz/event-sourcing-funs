using EventSourcing.POC.Domain.Events;
using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Entities
{
    /// <summary>
    /// Current state of the user entity.
    /// </summary>
    public class UserEntity: AggregateRoot 
    {
        // For reconstruction
        #pragma warning disable CS8618
        public UserEntity()
        {

        }
        #pragma warning restore CS8618


        public UserEntity(
            string username,
            string email
        )
        {
            Username = username;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }

        /*
        The aggregate creates events internally.
        This means nothing outside the aggregate should create an event.
        The methods that create events internally will have business
        to make the creation of events is aligned with the business logic.
        */

        /// <summary>
        /// This will create a UserCreatedEvent
        /// </summary>
        /// <param name="username">Username for user being created</param>
        /// <param name="email">Email for user being created</param>
        /// <returns></returns>
        public static UserEntity CreateUser(
            string username,
            string email
        )
        {
            var user = new UserEntity(
                username,
                email
            )
            {
                Id = Guid.NewGuid()    
            };

            user.AddEvent(new UserCreatedEvent(user.Id, user.Username, user.Email));

            return user;
        }

        protected override void ApplyEvent(Event @event)
        {
            Id = @event.AggregateId;
            if (@event.EventType == EventTypes.UserCreated)
            {
                var userCreatedEvent = (UserCreatedEvent)@event;
                Username = userCreatedEvent.Username;
                Email = userCreatedEvent.Email;
            }

            throw new NotImplementedException("Unknown event type: {@event.GetType()} can't be applied");
        }
    }
}