using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Modules.Fields.Core.CultivationHistories.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.CultivationHistories.Entities
{
    public class HarvestHistoryRecord : HistoryRecord
    {
        public Amount Amount { get; set; }
        public CropType CropType { get; set; }
        public Humidity Humidity { get; set; }
        public HarvestHistoryRecord(
            HistoryRecordId id,
            DateTime date,
            Amount amount,
            CropType cropType,
            Humidity humidity

        ) : base(id, date)
        {
            Amount = amount;
            CropType = cropType;
            Humidity = humidity;
        }
    }
}
