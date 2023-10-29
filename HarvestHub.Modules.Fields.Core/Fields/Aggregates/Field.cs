using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    public class Field : AggregateRoot<FieldId>
    {
        public Field(FieldId id) : base(id)
        {
        }
    }
}
