using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Weather.Api.Exceptions
{
    internal class WeatherApiRequestFailedException : HarvestHubException
    {
        public WeatherApiRequestFailedException() : base("Request to weather api has failed!")
        {
        }
    }
}
