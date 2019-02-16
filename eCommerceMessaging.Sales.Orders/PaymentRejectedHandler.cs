using System;
using System.Threading.Tasks;
using eCommerceMessaging.Billing.Messages.Events;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.Sales.Orders
{
    public class PaymentRejectedHandler : IHandleMessages<PaymentRejected>
    {
        private readonly ILogger<PaymentRejectedHandler> _logger;
        private readonly ISalesDatabase _database;

        public PaymentRejectedHandler(ISalesDatabase database, ILogger<PaymentRejectedHandler> logger)
        {
            _database = database;
            _logger = logger;

        }
        public Task Handle(PaymentRejected message, IMessageHandlerContext context)
        {
            _logger.LogInformation(
                $"Received payment rejected notification for Order {message.OrderId}. Sending email to user..."
            );
            
            // Get user for this order...
            // Send email...
            return Task.CompletedTask;
        }
    }
}