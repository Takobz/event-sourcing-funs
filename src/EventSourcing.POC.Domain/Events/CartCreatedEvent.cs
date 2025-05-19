using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{    public class CartCreatedEvent(
        Guid aggregateId,
        string cartName,
        string cartDescription
    ) : Event(aggregateId, EventTypes.CartCreated)
    {
        public string Name = cartName;
        public string Description = cartDescription;
    }
}