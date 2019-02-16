using eCommerceMessaging.BaseHost;
using eCommerceMessaging.Sales.Orders.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceMessaging.Sales.Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.WithArgs("eCommerceMessaging.Sales.Orders")
                .Start(services => 
                    services.AddTransient<ISalesDatabase, SalesDatabase>()
                );
        }
    }
}
