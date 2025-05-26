namespace EventSourcing.POC.Domain.Entities 
{
    /// <summary>
    /// Represents current state of a cart item
    /// </summary>
    public class CartItemEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public double Price { get; private set; } = 0;
        public int Quantity { get; private set; } = 0;
    }
}