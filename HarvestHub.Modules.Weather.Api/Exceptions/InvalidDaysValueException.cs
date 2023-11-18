using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Weather.Api.Exceptions
{
    internal class InvalidDaysValueException : HarvestHubException
    {
        public int Value { get; }
        public InvalidDaysValueException(int value) : base($"Provided days value: {value} is invalid! Days value should be positive number and smaller than 11!")
        {
            Value = value;
        }
    }
}
