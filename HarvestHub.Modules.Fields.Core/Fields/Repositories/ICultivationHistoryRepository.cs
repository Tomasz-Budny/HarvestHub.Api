using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Fields.Repositories
{
    public interface ICultivationHistoryRepository
    {
        Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, OwnerId ownerId, CancellationToken cancellationToken);
        Task UpdateAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken);

    }
}
