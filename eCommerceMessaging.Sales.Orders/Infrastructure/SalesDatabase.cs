using System;
using System.Collections.Generic;

namespace eCommerceMessaging.Sales.Orders.Infrastructure
{
    // This can be any database technology. 
    // It can differ between business components/components (microservices).
    public class SalesDatabase : ISalesDatabase
    {
        public string SaveOrder(IEnumerable<string> productIds, string userId, string shippingTypeId)
        {
            // For demo purpose...
            return Guid.NewGuid().ToString();
        }
    }
}