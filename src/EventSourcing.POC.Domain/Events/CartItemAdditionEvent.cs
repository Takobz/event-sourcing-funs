using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{
    public class CartItemAdditionEvent(
        Guid aggregateId
    ) : Event(aggregateId, EventTypes.CartItemAddition)
    {
        
    }
}