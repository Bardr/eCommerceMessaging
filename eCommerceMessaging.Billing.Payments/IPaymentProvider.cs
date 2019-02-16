namespace eCommerceMessaging.Billing.Payments
{
    public interface IPaymentProvider
    {
        PaymentConfirmation ChargeCreditCard(CardDetails details, double amount);
    }
}