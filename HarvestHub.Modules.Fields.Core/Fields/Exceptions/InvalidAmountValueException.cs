using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    public class InvalidAmountValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidAmountValueException(double value) : base($"Provided amount value: {value} is invalid!")
        {
            Value = value;
        }
    }
}
