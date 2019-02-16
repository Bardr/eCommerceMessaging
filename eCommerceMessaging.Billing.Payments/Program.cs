using eCommerceMessaging.BaseHost;
using eCommerceMessaging.Billing.Payments.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceMessaging.Billing.Payments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.WithArgs("eCommerceMessaging.Billing.Payments")
                .Start(services =>
                {
                    // Singleton to manage attempts
                    services.AddSingleton<IPaymentProvider, PaymentProvider>();
                    services.AddTransient<IPaymentDatabase, PaymentDatabase>();
                });
        }
    }
}
