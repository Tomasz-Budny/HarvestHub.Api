using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record HarvestHistoryRecordDto(
        Guid Id,
        DateTime Date,
        CropType CropType,
        double Amount,
        uint Humidity

    ) :HistoryRecordDto(Id, Date);
}
