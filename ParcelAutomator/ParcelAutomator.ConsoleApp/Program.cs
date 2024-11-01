using Microsoft.Extensions.DependencyInjection;
using ParcelAutomator.Core;

namespace ParcelAutomator.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = ConfigureServices();

            var app = serviceProvider.GetRequiredService<App>();
            app.Run();


        }

        private static ServiceProvider ConfigureServices()
        {

            var services = new ServiceCollection();
            services.WithCoreServices();
            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }
    }
}
