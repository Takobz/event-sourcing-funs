using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{
    public class CartItemAddedEvent(
        Guid aggregateId
    ) : Event(aggregateId, EventTypes.CartItemAdded)
    {
        
    }
}