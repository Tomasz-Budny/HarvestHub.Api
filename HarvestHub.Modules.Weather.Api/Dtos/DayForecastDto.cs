﻿namespace HarvestHub.Modules.Weather.Api.Dtos
{
    public class DayForecastDto
    {
        public double Temperature { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public WeatherStatus WeatherStatus { get; set; }
        public int RainChances { get; set; }
    }    
}
