using HarvestHub.Modules.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Modules.Fields.Core.CultivationHistories.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.CultivationHistories.Repositories
{
    public interface ICultivationHistoryRepository
    {
        Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, CancellationToken cancellationToken);
        Task UpdateAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken);

    }
}
