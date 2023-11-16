namespace HarvestHub.Modules.Weather.Api.Dtos
{
    internal class DayForecastDto
    {
        public double Temperature { get; set; }
        public string WeekDay { get; set; }
        public WeatherStatus WeatherStatus { get; set; }
        public int RainChances { get; set; }
    }    
}
