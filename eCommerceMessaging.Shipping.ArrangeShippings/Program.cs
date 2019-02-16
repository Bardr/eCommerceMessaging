using eCommerceMessaging.BaseHost;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceMessaging.Shipping.ArrangeShippings
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Host.WithArgs("eCommerceMessaging.Shipping.ArrangeShippings")
                .Start(services =>
                {
                    // Singleton to manage orders list
                    services.AddSingleton<IShippingDatabase, ShippingDatabase>();
                    services.AddTransient<IShippingProvider, ShippingProvider>();
                });
        }
    }
}