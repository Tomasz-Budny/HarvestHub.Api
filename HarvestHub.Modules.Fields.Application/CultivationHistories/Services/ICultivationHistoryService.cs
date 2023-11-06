using HarvestHub.Modules.Fields.Core.Fields.Aggregates;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Services
{
    public interface ICultivationHistoryService
    {
        Task<CultivationHistory> GetByFieldId(Guid fieldId, Guid ownerId, CancellationToken cancellationToken);
    }
}
