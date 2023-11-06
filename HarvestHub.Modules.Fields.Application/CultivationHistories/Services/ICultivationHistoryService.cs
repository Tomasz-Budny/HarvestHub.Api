using HarvestHub.Modules.Fields.Core.CultivationHistories.Aggregates;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Services
{
    public interface ICultivationHistoryService
    {
        Task<CultivationHistory> GetByFieldId(Guid fieldId, Guid ownerId, CancellationToken cancellationToken);
    }
}
