namespace EventSourcing.POC.Domain.ValueObjects 
{
    public static class EventTypes 
    {
        public const string UserCreated = "UserCreated";
        public const string CartCreated = "CartCreated";
        public const string CartItemAdded = "CartItemAdded";
        public const string CartItemModified = "CartItemModified";
        public const string CartItemDeleted = "CartItemDeleted";
        public const string CartItemCreated = "CartItemCreated";
    }
}