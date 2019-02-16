using System.Collections.Generic;

namespace eCommerceMessaging.Sales.Orders
{
    public interface ISalesDatabase
    {
        string SaveOrder(IEnumerable<string> productIds, string userId, string shippingTypeId);
    }
}