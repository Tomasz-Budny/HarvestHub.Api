using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    
    internal class InvalidHexColorException : HarvestHubException
    {
        public string Value { get; }
        public InvalidHexColorException(string value) : base($"Provided value: {value} is invalid hexadecimal color!")
        {
            Value = value;
        }
    }
}
