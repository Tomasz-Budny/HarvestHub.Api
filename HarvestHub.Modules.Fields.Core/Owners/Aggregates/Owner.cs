using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Owners.Aggregates
{
    public class Owner : AggregateRoot<OwnerId>
    {
        public Owner(OwnerId id) : base(id)
        {
        }
    }
}
