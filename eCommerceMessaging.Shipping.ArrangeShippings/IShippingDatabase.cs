namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public interface IShippingDatabase
    {
        void AddOrderDetails(ShippingOrder order);
        string GetCustomerAddress(string orderId);
    }
}