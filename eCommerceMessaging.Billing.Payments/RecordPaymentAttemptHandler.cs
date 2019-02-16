using System;
using System.Threading.Tasks;
using eCommerceMessaging.Billing.Messages.Commands;
using eCommerceMessaging.Billing.Messages.Events;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.Billing.Payments
{
    public class RecordPaymentAttemptHandler : IHandleMessages<RecordPaymentAttempt>
    {
        private readonly IPaymentDatabase _paymentDatabase;
        private readonly ILogger<RecordPaymentAttemptHandler> _logger;

        public RecordPaymentAttemptHandler(
            IPaymentDatabase paymentDatabase,
            ILogger<RecordPaymentAttemptHandler> logger)
        {
            _paymentDatabase = paymentDatabase;
            _logger = logger;

        }
        public async Task Handle(RecordPaymentAttempt message, IMessageHandlerContext context)
        {
            _paymentDatabase.SavePaymentAttempt(
                message.OrderId, message.Status
            );

            if (message.Status == PaymentStatus.Accepted)
            {
                var evnt = new PaymentAccepted
                {
                    OrderId = message.OrderId
                };

                await context.Publish(evnt);

                _logger.LogInformation(
                    $"Received payment accepted notification for Order {message.OrderId}. Published PaymentAccepted event."
                );
            }
            else
            {
                // Publish a payment rejected event
                var evnt = new PaymentRejected
                {
                    OrderId = message.OrderId
                };

                await context.Publish(evnt);

                _logger.LogInformation(
                    $"Received payment rejected notification for Order {message.OrderId}. Published PaymentRejected event."
                );
            }
        }
    }
}