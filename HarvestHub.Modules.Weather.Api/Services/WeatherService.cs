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
        public async Task<object> GetDayForecast(double latitude, double longitude, int days)
        {
            var url = $"?key={_weatherApiOptions.Key}&q={latitude.ToString().Replace(',', '.')},{longitude.ToString().Replace(',', '.')}&days={days}&aqi=no&alerts=no";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return response;
        }
    }
}
