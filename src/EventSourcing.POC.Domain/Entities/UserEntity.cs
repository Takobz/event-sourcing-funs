using EventSourcing.POC.Domain.Events;

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
            Guid Id,
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
        public UserEntity CreateUser(
            string username,
            string email
        )
        {
            var user = new UserEntity(
                Guid.NewGuid(),
                username,
                email
            );

            AddEvent(new UserCreatedEvent(Guid.NewGuid(), user.Username, user.Email));

            return user;
        }

        protected override void ApplyEvent(Event @event)
        {
            Id = @event.AggregateId;
            if (@event.GetType() == typeof(UserCreatedEvent))
            {
                var userCreatedEvent = (UserCreatedEvent)@event;
                this.Username = userCreatedEvent.Username;
                this.Email = userCreatedEvent.Email;
            }
            throw new NotImplementedException();
        }
    }
}