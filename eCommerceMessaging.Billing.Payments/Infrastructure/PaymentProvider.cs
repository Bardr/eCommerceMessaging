using System;
using eCommerceMessaging.Billing.Messages.Commands;

namespace eCommerceMessaging.Billing.Payments.Infrastructure
{
    public class PaymentProvider : IPaymentProvider
    {
        private int _attempts;
        public PaymentConfirmation ChargeCreditCard(CardDetails details, double amount)
        {
            if (_attempts < 1)
            {
                _attempts++;
                throw new Exception(
                    "Service unavailable. Down for maintenance."
                );
            }

            // To keep the example focused on what's relevant.
            return new PaymentConfirmation
            {
                // We have 20% chance that payment provider will reject payment.
                // Simulates some logic to exploit all possibilities of system.
                Status = new Random().Next(10) > 7 ? PaymentStatus.Rejected : PaymentStatus.Accepted
            };
        }
    }
}