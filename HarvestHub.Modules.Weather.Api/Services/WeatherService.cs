using HarvestHub.Modules.Weather.Api.Services.Options;
using Microsoft.Extensions.Options;

namespace HarvestHub.Modules.Weather.Api.Services
{
    internal class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherApiOptions _weatherApiOptions;

        public WeatherService(HttpClient httpClient, IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _httpClient = httpClient;
            _weatherApiOptions = weatherApiOptions.Value;
        }
        public Task<object> GetDayForecast(double latitude, double longitude, int days)
        {
            throw new NotImplementedException();
        }
    }
}
