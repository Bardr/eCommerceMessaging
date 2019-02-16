using eCommerceMessaging.Billing.Messages.Commands;

namespace eCommerceMessaging.Billing.Payments
{
    public class PaymentDatabase : IPaymentDatabase
    {
        public void SavePaymentAttempt(string orderId, PaymentStatus status)
        {
            // Save it to your favorite database...
        }


        // To keep the example focused on what's relevant
        public CardDetails GetCardDetailsFor(string userId) => new CardDetails();
    }

    public class CardDetails
    {
        // ...
    }

    public class PaymentConfirmation
    {
        public PaymentStatus Status { get; set; }
    }
}
