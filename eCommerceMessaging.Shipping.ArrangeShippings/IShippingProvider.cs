namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public interface IShippingProvider
    {
        ShippingConfirmation ArrangeShippingFor(string address, string referenceCode);
    }
}