using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Domain.Events 
{    public class CartItemCreatedEvent(
        Guid aggregationId,
        string cartItemName,
        string cartItemDescription,
        double cartItemPrice,
        int cartItemQuantity
    ) : Event(aggregationId, EventTypes.CartItemCreated) 
    {
        public string Name = cartItemName;
        public string Description = cartItemDescription;
        public double Price = cartItemPrice;
        public int Quantity = cartItemQuantity;
    }
}