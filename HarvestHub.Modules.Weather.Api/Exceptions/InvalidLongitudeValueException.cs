using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Weather.Api.Exceptions
{
    internal class InvalidLongitudeValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidLongitudeValueException(double value) : base($"Provided longitude value: {value} is invalid!")
        {
            Value = value;
        }
    }
}
