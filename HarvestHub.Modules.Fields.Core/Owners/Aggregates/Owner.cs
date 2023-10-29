using HarvestHub.Modules.Fields.Core.Owners.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Owners.Aggregates
{
    public class Owner : AggregateRoot<OwnerId>
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        
        public Owner(OwnerId id) : base(id)
        {
        }
    }
}
