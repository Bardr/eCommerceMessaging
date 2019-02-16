using System.Collections.Generic;
using System.Linq;

namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public class ShippingDatabase : IShippingDatabase
    {
        private readonly List<ShippingOrder> _orders;

        public ShippingDatabase()
        {
            _orders = new List<ShippingOrder>();
        }
        public void AddOrderDetails(ShippingOrder order)
        {
            _orders.Add(order);
        }
        public string GetCustomerAddress(string orderId)
        {
            var order = _orders.Single(o => o.OrderId == orderId);
            return $"{order.UserId}, 96 Perfect Street";
        }
    }
}