using HarvestHub.Modules.Weather.Api.Services;
using HarvestHub.Modules.Weather.Api.Services.Options;
using HarvestHub.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HarvestHub.Modules.Weather.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddWeatherModule(this IServiceCollection services, IConfiguration configuration)
        {
            var weatherApiOptions = configuration.GetOptions<WeatherApiOptions>(WeatherApiOptions.SectionName);
            services.AddSingleton(Options.Create(weatherApiOptions));

            services.AddScoped<IWeatherService, WeatherService>();

            services.AddHttpClient<IWeatherService, WeatherService>((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri($"http://api.weatherapi.com/v1/");
            });

            return services;
        }
    }
}
