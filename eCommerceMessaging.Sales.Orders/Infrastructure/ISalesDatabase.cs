using System.Collections.Generic;

namespace eCommerceMessaging.Sales.Orders.Infrastructure
{
    public interface ISalesDatabase
    {
        string SaveOrder(IEnumerable<string> productIds, string userId, string shippingTypeId);
    }
}