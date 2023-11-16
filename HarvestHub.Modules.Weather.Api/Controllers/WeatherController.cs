using HarvestHub.Modules.Weather.Api.Dtos;
using HarvestHub.Modules.Weather.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Weather.Api.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayForecastDto>>> GetDayForecasts([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] int days)
        {
            var dayForecasts = await _weatherService.GetDayForecast(latitude, longitude, days);

            return Ok(dayForecasts);
        }
    }
}
