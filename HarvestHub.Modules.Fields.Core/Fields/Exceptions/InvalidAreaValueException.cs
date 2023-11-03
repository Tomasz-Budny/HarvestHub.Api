using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    internal class InvalidAreaValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidAreaValueException(double value) : base($"Provided area value: {value} is invalid! Area value should be positive number!")
        {
            Value = value;
        }
    }
}
