using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    internal class InvalidHumidityValueException : HarvestHubException
    {
        public uint Value { get; }
        public InvalidHumidityValueException(uint value) : base($"Provided humidity value: {value} is invalid!")
        {
            Value = value;
        }
    }
}
