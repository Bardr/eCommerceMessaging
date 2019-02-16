namespace eCommerceMessaging.Shipping.ArrangeShippings.Infrastructure
{
    public interface IShippingProvider
    {
        ShippingConfirmation ArrangeShippingFor(string address, string referenceCode);
    }
}