namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public class ShippingProvider : IShippingProvider
    {
        public ShippingConfirmation ArrangeShippingFor(string address, string referenceCode)
        {
            return new ShippingConfirmation
            {
                Status = ShippingStatus.Success
            };
        }
    }

    public class ShippingConfirmation
    {
        public ShippingStatus Status { get; set; }
    }

    public enum ShippingStatus
    {
        Success,
        Failure
    }
}