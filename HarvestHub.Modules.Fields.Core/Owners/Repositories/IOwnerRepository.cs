using HarvestHub.Modules.Fields.Core.Owners.Aggregates;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Owners.Repositories
{
    public interface IOwnerRepository
    {
        Task UpdateAsync(Owner field);
        Task<Owner?> GetAsync(OwnerId ownerId);
    }
}
