using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record AddHarvestHistoryRecordByFieldIdRequest(
        DateTime Date,
        double Amount,
        CropType CropType,
        uint Humidity
    );
}
