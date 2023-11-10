using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record AddFertilizationHistoryRecordByFieldIdRequest(
        DateTime Date,
        double Amount,
        FertilizerType FertilizerType
    );
}
