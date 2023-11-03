using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Fields.Entities
{
    public class FertilizationHistoryRecord : HistoryRecord
    {
        public FertilizerType FertilizerType { get; }
        public Amount Amount { get; }
        public FertilizationHistoryRecord(
            HistoryRecordId id, 
            FieldId fieldId, 
            DateTime date,
            FertilizerType fertilizerType,
            Amount amount

        ) : base(id, fieldId, date)
        {
            FertilizerType = fertilizerType;
            Amount = amount;
        }
    }
}
