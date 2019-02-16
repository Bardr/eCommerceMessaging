namespace eCommerceMessaging.Sales.Messages.Events
{
    public class OrderCreatedV2 : OrderCreated
    {
        public string AddressId { get; set; }
    }
}