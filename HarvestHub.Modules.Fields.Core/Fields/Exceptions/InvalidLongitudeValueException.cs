using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    internal class InvalidLongitudeValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidLongitudeValueException(double value) 
            : base($"Provided longitude value: {value} is invalid! Value should be a number between -180 and 180")
        {
            Value = value;
        }
    }
}
