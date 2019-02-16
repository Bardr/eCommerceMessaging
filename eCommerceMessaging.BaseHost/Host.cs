using System;
using System.Runtime.Loader;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace eCommerceMessaging.BaseHost
{
    public class Host
    {
        private ManualResetEvent Shutdown = new ManualResetEvent(false);
        private ManualResetEventSlim Complete = new ManualResetEventSlim();

        private readonly string _hostName;
        private ILogger<Host> _logger;

        private Host(string hostName)
        {
            _hostName = hostName;
        }

        public static Host WithArgs(string name)
        {
            return new Host(name);
        }

        public void Start(Action<IServiceCollection> configure = null)
        {
            var services = new ServiceCollection();
            ConfigureLogging(services);

            _logger = services.BuildServiceProvider().GetService<ILogger<Host>>();
            try
            {
                var ended = new ManualResetEventSlim();
                var starting = new ManualResetEventSlim();


                _logger.LogInformation($"{_hostName}: Starting...");
                // Console.WriteLine($"{_hostName}: Starting...");
                if (configure != null)
                {
                    configure(services);
                }

                ConfigureNServiceBusEndpoint(services);

                // Capture SIGTERM  
                AssemblyLoadContext.Default.Unloading += Default_Unloading;

                // Wait for a signal
                Shutdown.WaitOne();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                _logger.LogError($"{_hostName}: {ex.Message}");
            }
            finally
            {
                _logger.LogInformation($"{_hostName}: Cleaning up resources...");
                // Console.WriteLine($"{_hostName}: Cleaning up resources...");
                // Clean...
            }

            _logger.LogInformation($"{_hostName}: Exiting...");
            // Console.WriteLine($"{_hostName}: Exiting...");
            Complete.Set();
        }

        private void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddFilter(level => level >= LogLevel.Information);
                configure.AddConsole();
            });
        }

        private void ConfigureNServiceBusEndpoint(IServiceCollection services)
        {
            var endpointConfiguration = new EndpointConfiguration($"{_hostName}");
            endpointConfiguration.EnableInstallers();

            var conventions = endpointConfiguration.Conventions();
            conventions.DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"));
            conventions.DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"));

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=rabbitmq");

            endpointConfiguration.UseContainer<ServicesBuilder>(customizations: customizations =>
            {
                customizations.ExistingServices(services);
            });

            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

            services.AddSingleton(sp => endpoint);
        }

        private void Default_Unloading(AssemblyLoadContext obj)
        {
            _logger.LogInformation($"{_hostName}: Shutting down in response to SIGTERM.");
            // Console.WriteLine($"{_hostName}: Shutting down in response to SIGTERM.");
            Shutdown.Set();
            Complete.Wait();
        }
    }
}