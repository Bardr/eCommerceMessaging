namespace eCommerceMessaging.Billing.Payments.Infrastructure
{
    public interface IPaymentProvider
    {
        PaymentConfirmation ChargeCreditCard(CardDetails details, double amount);
    }
}