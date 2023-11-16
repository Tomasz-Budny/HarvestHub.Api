using HarvestHub.Modules.Weather.Api.Dtos.Externals.WeatherApi;
using HarvestHub.Modules.Weather.Api.Dtos;

namespace HarvestHub.Modules.Weather.Api.Mappers
{
    internal static class WeatherMapper
    {
        public static IEnumerable<DayForecastDto> MapToDayForecastDto(WeatherApiResponse response)
        {
            return response.forecast.forecastday.Select(forecastDay => new DayForecastDto
            {
                Temperature = forecastDay.day.avgtemp_c,
                WeekDay = DateTime.Parse(forecastDay.date).DayOfWeek.ToString(),
                WeatherStatus = MapToWeatherStatus(forecastDay.day.condition),
                RainChances = forecastDay.day.daily_chance_of_rain
            });
        }

        private static WeatherStatus MapToWeatherStatus(string condition)
        {
            switch (condition.ToLower())
            {
                case "sunny":
                    return WeatherStatus.Sunny;
                case "cloudy":
                    return WeatherStatus.Cloudy;
                case "overcast":
                    return WeatherStatus.Overcast;
                default:
                    throw new Exception($"Unknown weather condition: {condition}");
            }
        }
    }
}
