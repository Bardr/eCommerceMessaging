using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceMessaging.Sales.Messages.Events;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public class OrderCreatedHandler : IHandleMessages<OrderCreatedV2>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;
        private readonly IShippingDatabase _database;

        public OrderCreatedHandler(IShippingDatabase database, ILogger<OrderCreatedHandler> logger)
        {
            _database = database;
            _logger = logger;

        }
        
        public Task Handle(OrderCreatedV2 message, IMessageHandlerContext context)
        {
            _logger.LogInformation(
                $"Storing order: {message.OrderId} made by {message.UserId} with shipping {message.ShippingTypeId} to the addressId {message.AddressId}"
            );

            var order = new ShippingOrder
            {
                UserId = message.UserId,
                OrderId = message.OrderId,
                AddressId = message.AddressId,
                ShippingTypeId = message.ShippingTypeId
            };

            _database.AddOrderDetails(order);

            return Task.CompletedTask;
        }
    }
}