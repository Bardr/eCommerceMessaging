using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using eCommerceMessaging.Billing.Messages.Events;
using eCommerceMessaging.Shipping.ArrangeShippings.Infrastructure;
using eCommerceMessaging.Shipping.Messages.Events;
using NServiceBus;

namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public class PaymentAcceptedHandler : IHandleMessages<PaymentAccepted>
    {
        private readonly ILogger<PaymentAcceptedHandler> _logger;
        private readonly IShippingDatabase _database;
        private readonly IShippingProvider _shippingProvider;

        public PaymentAcceptedHandler(
            IShippingDatabase database,
            IShippingProvider shippingProvider,
            ILogger<PaymentAcceptedHandler> logger
            )
        {
            _database = database;
            _shippingProvider = shippingProvider;
            _logger = logger;

        }

        public async Task Handle(PaymentAccepted message, IMessageHandlerContext context)
        {
            var address = _database.GetCustomerAddress(
                message.OrderId
            );
            var confirmation = _shippingProvider.ArrangeShippingFor(
                address, message.OrderId
            );
            if (confirmation.Status == ShippingStatus.Success)
            {
                var evnt = new ShippingArranged
                {
                    OrderId = message.OrderId
                };
                await context.Publish(evnt);

                _logger.LogInformation(
                    $"Arranged order {message.OrderId} to {address}"
                );
            }
            else
            {
                // ...
            }
        }
    }
}