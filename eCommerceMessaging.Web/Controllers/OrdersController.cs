using System;
using System.Threading.Tasks;
using eCommerceMessaging.Sales.Messages.Commands;
using eCommerceMessaging.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace eCommerceMessaging.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IEndpointInstance _endpointInstance;

        public OrdersController(IEndpointInstance endpointInstance)
        {
            _endpointInstance = endpointInstance;
        }

        [HttpPost]
        public async Task<IActionResult> Place([FromBody] PlaceOrderDto input)
        {
            var realProductIds = input.ProductsIds.Split(',');
            var placeOrderCommand = new PlaceOrder
            {
                UserId = input.UserId,
                ProductIds = realProductIds,
                ShippingTypeId = input.ShippingTypeId,
                TimeStamp = DateTime.Now
            };
            await _endpointInstance.Send("eCommerceMessaging.Sales.Orders", placeOrderCommand);

            return Ok("Your order has been placed. You will receive email confirmation shortly.");
        }
    }
}