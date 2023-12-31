using HarvestHub.Modules.Fields.Core.Owners.Aggregates;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Owners.Repositories
{
    public interface IOwnerRepository
    {
        Task UpdateAsync(Owner owner, CancellationToken cancellationToken);
        Task<Owner?> GetAsync(OwnerId ownerId, CancellationToken cancellationToken);
        Task AddAsync(Owner owner, CancellationToken cancellationToken);
    }
}
