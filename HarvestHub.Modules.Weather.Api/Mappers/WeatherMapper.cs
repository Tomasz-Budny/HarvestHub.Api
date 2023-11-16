using HarvestHub.Modules.Weather.Api.Dtos.Externals.WeatherApi;
using HarvestHub.Modules.Weather.Api.Dtos;

namespace HarvestHub.Modules.Weather.Api.Mappers
{
    internal static class WeatherMapper
    {
        public static IEnumerable<DayForecastDto> MapToDayForecastDto(WeatherApiResponse response)
        {
            return response.Forecast.Forecastday.Select(forecastDay => new DayForecastDto
            {
                Temperature = forecastDay.Day.Avgtemp_c,
                WeekDay = forecastDay.Date.DayOfWeek,
                WeatherStatus = MapToWeatherStatus(forecastDay.Day.Condition.Code),
                RainChances = forecastDay.Day.Daily_chance_of_rain
            }); ;
        }

        private static WeatherStatus MapToWeatherStatus(int conditionCode)
        {
            if(conditionCode == 1000) 
            {
                return WeatherStatus.Sunny;
            }

            if(conditionCode >= 1003 && conditionCode <= 1006)
            {
                return WeatherStatus.Cloudy;
            }

            if(conditionCode >= 1009 && conditionCode <= 1030)
            {
                return WeatherStatus.Overcast;
            }

            if (conditionCode >= 1063 && conditionCode <= 1282)
            {
                return WeatherStatus.Rainy;
            }

            return WeatherStatus.Unknown;
        }
    }
}
