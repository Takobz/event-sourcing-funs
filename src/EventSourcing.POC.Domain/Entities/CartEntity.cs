using EventSourcing.POC.Domain.Events;

namespace EventSourcing.POC.Domain.Entities 
{
    /// <summary>
    /// Current state of the Cart.
    /// </summary>
    public class CartEntity : Entity 
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public IEnumerable<CartItemEntity> CartItems = [];

        /// <summary>
        /// Call this to create a new cart.
        /// </summary>
        /// <param name="event">event with all the state data on creation</param>
        public void Apply(CartCreationEvent @event)
        {
            Id = @event.AggregateId;
            Name = @event.Name;
            Description = @event.Description;
            CartItems = [];
        }
    }
}