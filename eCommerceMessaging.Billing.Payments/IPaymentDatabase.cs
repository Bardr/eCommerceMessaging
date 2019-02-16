using eCommerceMessaging.Billing.Messages.Commands;

namespace eCommerceMessaging.Billing.Payments
{
    public interface IPaymentDatabase
    {
        void SavePaymentAttempt(string orderId, PaymentStatus status);
        CardDetails GetCardDetailsFor(string userId);
    }
}