using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Fields.Entities
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
