namespace HarvestHub.Modules.Weather.Api.Dtos.Externals.WeatherApi
{
    public class WeatherApiResponse
    {
        public Forecast forecast { get; set; }
    }

    public class Forecast
    {
        public List<ForecastDayDto> forecastday { get; set; }
    }

    public class ForecastDayDto
    {
        public string date { get; set; }
        public DayDto day { get; set; }
    }

    public class DayDto
    {
        public double avgtemp_c { get; set; }
        public string condition { get; set; }
        public int daily_chance_of_rain { get; set; }
    }
}
