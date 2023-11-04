using HarvestHub.Modules.Fields.Core.Fields.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record AddHarvestHistoryRecordRequest(
        DateTime Date,
        double Amount,
        CropType CropType,
        uint Humidity
    );
}
