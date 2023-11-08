using System.Text.Json.Serialization;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    [JsonDerivedType(typeof(HarvestHistoryRecordDto))]
    public record HistoryRecordDto(
        Guid Id,
        DateTime Date
    );
}
