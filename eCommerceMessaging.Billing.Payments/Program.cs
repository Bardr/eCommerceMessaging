﻿using System;
using System.Runtime.Loader;
using System.Threading;
using eCommerceMessaging.BaseHost;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

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