namespace EventSourcing.POC.Domain.ValueObjects 
{
    public static class EventTypes 
    {
        public const string UserCreation = "UserCreation";
        public const string CartCreation = "CartCreation";
        public const string CartItemAddition = "CartItemAdd";
        public const string CartItemModify = "CartItemModify";
        public const string CartItemDelete = "CartItemDelete";
        public const string CartItemCreation = "CartItemCreate";
    }
}