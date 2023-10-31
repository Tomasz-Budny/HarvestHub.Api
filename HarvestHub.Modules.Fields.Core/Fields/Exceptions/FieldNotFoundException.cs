using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    public class FieldNotFoundException : HarvestHubException
    {
        public Guid Id { get; }
        public FieldNotFoundException(Guid value) : base($"Field with provided Id: {value} has not been found for this owner!")
        {
            Id = value;
        }
    }
}
