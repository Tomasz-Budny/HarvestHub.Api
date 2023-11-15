using HarvestHub.Modules.Weather.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Weather.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddWeatherModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWeatherService, WeatherService>();

            services.AddHttpClient<IWeatherService, WeatherService>((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri($"http://api.weatherapi.com/v1/forecast.json");
            });

            return services;
        }
    }
}
