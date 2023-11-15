namespace HarvestHub.Modules.Weather.Api.Services
{
    internal interface IWeatherService
    {
        Task<object> GetDayForecast(double latitude, double longitude, int days);
    }
}
