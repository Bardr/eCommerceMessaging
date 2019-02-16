using System;
using System.Threading.Tasks;
using eCommerceMessaging.Billing.Messages.Commands;
using eCommerceMessaging.Billing.Payments.Infrastructure;
using eCommerceMessaging.Sales.Messages.Events;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.Billing.Payments
{
    public class OrderCreatedHandler : IHandleMessages<OrderCreated>
    {
        private readonly IPaymentDatabase _paymentDatabase;
        private readonly IPaymentProvider _paymentProvider;
        private readonly ILogger<OrderCreatedHandler> _logger;

        public OrderCreatedHandler(
            IPaymentDatabase paymentDatabase,
            IPaymentProvider paymentProvider,
            ILogger<OrderCreatedHandler> logger)
        {
            _paymentDatabase = paymentDatabase;
            _paymentProvider = paymentProvider;
            _logger = logger;

        }
        public async Task Handle(OrderCreated message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Received order created event for {message.OrderId}.");

            var cardDetials = _paymentDatabase.GetCardDetailsFor(message.UserId);
            var confirmation = _paymentProvider.ChargeCreditCard(cardDetials, message.Amount);

            var command = new RecordPaymentAttempt
            {
                OrderId = message.OrderId,
                Status = confirmation.Status
            };

            await context.SendLocal(command);
        }
    }
}