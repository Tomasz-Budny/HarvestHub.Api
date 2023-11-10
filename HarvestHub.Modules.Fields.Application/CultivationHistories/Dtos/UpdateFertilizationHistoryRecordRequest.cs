using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record UpdateFertilizationHistoryRecordRequest(
        DateTime Date,
        FertilizerType FertilizerType,
        double Amount
    );
}
