using EventSourcing.POC.Domain.Events;

namespace EventSourcing.POC.Domain.Entities
{
    /// <summary>
    /// Current state of the user entity.
    /// </summary>
    public class UserEntity(
        string username,
        string email
    ) : Entity 
    {
        public string Username { get; private set; } = username;
        public string Email { get; private set; } = email;

        /// <summary>
        /// Apply user state's on creation.
        /// </summary>
        public void Apply(UserCreationEvent @event)
        {
            Id = @event.AggregateId;
            Username = @event.Username;
            Email = @event.Email;
        }
    }
}