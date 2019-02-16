using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceMessaging.Sales.Messages.Commands;
using eCommerceMessaging.Sales.Messages.Events;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.Sales.Orders
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private readonly ILogger<PlaceOrderHandler> _logger;
        private readonly ISalesDatabase _salesDatabase;

        public PlaceOrderHandler(ISalesDatabase database, ILogger<PlaceOrderHandler> logger)
        {
            _salesDatabase = database;
            _logger = logger;

        }

        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            var orderId = _salesDatabase.SaveOrder(message.ProductIds, message.UserId, message.ShippingTypeId);

            _logger.LogInformation(
                $"Created order {orderId}: Products: {string.Join(",", message.ProductIds)} with shipping {message.ShippingTypeId} made by user: {message.UserId}"
            );


            var orderCreatedEvent = new OrderCreatedV2
            {
                OrderId = orderId,
                UserId = message.UserId,
                ProductIds = message.ProductIds,
                ShippingTypeId = message.ShippingTypeId,
                TimeStamp = DateTime.Now,
                Amount = CalculateCostOf(message.ProductIds),
                // Get address from database, saved from another event such as UserAddedAddress
                AddressId = Guid.NewGuid().ToString()
            };

            await context.Publish(orderCreatedEvent);
        }

        private double CalculateCostOf(IEnumerable<string> productIds)
        {
            // Some very complex logic...
            return 1000.00;
        }
    }
}