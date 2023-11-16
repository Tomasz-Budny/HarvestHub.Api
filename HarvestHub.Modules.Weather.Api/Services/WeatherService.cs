﻿using HarvestHub.Modules.Weather.Api.Dtos;
using HarvestHub.Modules.Weather.Api.Dtos.Externals.WeatherApi;
using HarvestHub.Modules.Weather.Api.Exceptions;
using HarvestHub.Modules.Weather.Api.Mappers;
using HarvestHub.Modules.Weather.Api.Services.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

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
        public async Task<IEnumerable<DayForecastDto>> GetDayForecast(double latitude, double longitude, int days)
        {
            var url = $"forecast.json?key={_weatherApiOptions.Key}&q={latitude.ToString().Replace(',', '.')},{longitude.ToString().Replace(',', '.')}&days={days}&aqi=no&alerts=no";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new WeatherApiRequestFailedException();
            }

            var weatherApiResponse = await response.Content.ReadFromJsonAsync<WeatherApiResponse>();

            var dayForecasts = WeatherMapper.MapToDayForecastDto(weatherApiResponse);

            return dayForecasts;
        }
    }
}
