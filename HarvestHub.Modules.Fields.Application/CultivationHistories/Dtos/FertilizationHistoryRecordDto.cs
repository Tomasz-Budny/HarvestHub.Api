using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record FertilizationHistoryRecordDto(
        Guid Id,
        DateTime Date,
        FertilizerType FertilizerType,
        double Amount

    ) : HistoryRecordDto(Id, Date);
}
