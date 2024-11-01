using Microsoft.Extensions.DependencyInjection;
using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.Core
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection WithCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IParcelReader, ParcelReader>();
            services.AddScoped<IParcelProcessorService, ParcelProcessorService>();
            return services;
        }


    }
}
