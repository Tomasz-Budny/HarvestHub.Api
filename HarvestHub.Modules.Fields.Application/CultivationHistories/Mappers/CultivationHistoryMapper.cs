using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Entities;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Mappers
{
    public static class CultivationHistoryMapper
    {
        public static HarvestHistoryRecordDto MapToHarvestHistoryRecordDto(HarvestHistoryRecord record)
        {
            return new HarvestHistoryRecordDto(record.Id, record.Date, record.CropType, record.Amount, record.Humidity);
        }
    }
}
