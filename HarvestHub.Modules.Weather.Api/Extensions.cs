using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Weather.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddWeatherModule(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
