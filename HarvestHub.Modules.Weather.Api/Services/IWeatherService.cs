using HarvestHub.Modules.Weather.Api.Dtos;

namespace HarvestHub.Modules.Weather.Api.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<DayForecastDto>> GetDayForecast(double latitude, double longitude, int days);
    }
}
