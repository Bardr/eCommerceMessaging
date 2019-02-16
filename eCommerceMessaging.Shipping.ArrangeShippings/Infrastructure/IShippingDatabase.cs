namespace eCommerceMessaging.Shipping.ArrangeShippings.Infrastructure
{
    public interface IShippingDatabase
    {
        void AddOrderDetails(ShippingOrder order);
        string GetCustomerAddress(string orderId);
    }
}