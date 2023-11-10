using System.Text.Json.Serialization;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    [JsonDerivedType(typeof(HarvestHistoryRecordDto))]
    [JsonDerivedType(typeof(FertilizationHistoryRecordDto))]
    public record HistoryRecordDto(Guid Id, DateTime Date)
    {
        public string Type { get; set; } = "Unknown";
    }
}
