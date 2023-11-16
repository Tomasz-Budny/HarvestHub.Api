namespace HarvestHub.Modules.Weather.Api.Dtos.Externals.WeatherApi
{
    public class WeatherApiResponse
    {
        public Forecast Forecast { get; set; }
    }

    public class Forecast
    {
        public List<ForecastDayDto> Forecastday { get; set; }
    }

    public class ForecastDayDto
    {
        public DateTime Date { get; set; }
        public DayDto Day { get; set; }
    }

    public class DayDto
    {
        public double Avgtemp_c { get; set; }
        public ConditionDto Condition { get; set; }
        public int Daily_chance_of_rain { get; set; }
    }

    public class ConditionDto
    {
        public int Code { get; set; }
    }
}
