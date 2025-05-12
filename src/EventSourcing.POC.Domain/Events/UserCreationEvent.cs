using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{
    /// <summary>
    /// User creation event. Should have all props I need to create a user.
    /// </summary>
    /// <param name="aggregateId"></param>
    public class UserCreationEvent(
        Guid aggregateId,
        string username,
        string email
    ) : Event(aggregateId, EventTypes.UserCreation)
    {
        public string Username { get; } = username;
        public string Email { get; } = email;
    }
}