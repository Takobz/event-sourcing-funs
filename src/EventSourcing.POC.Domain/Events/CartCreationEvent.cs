using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{
    public class CartCreationEvent(
        Guid aggregateId,
        string cartName,
        string cartDescription
    ) : Event(aggregateId, EventTypes.CartCreation)
    {
        public string Name = cartName;
        public string Description = cartDescription;
    }
}