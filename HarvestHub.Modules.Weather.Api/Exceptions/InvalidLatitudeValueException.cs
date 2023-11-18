using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Weather.Api.Exceptions
{
    internal class InvalidLatitudeValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidLatitudeValueException(double value) : base($"Provided latitude value: {value} is invalid!")
        {
            Value = value;
        }
    }
}
