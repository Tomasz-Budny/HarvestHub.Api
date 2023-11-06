using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Modules.Fields.Core.CultivationHistories.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.CultivationHistories.Entities
{
    public class FertilizationHistoryRecord : HistoryRecord
    {
        public FertilizerType FertilizerType { get; }
        public Amount Amount { get; }
        public FertilizationHistoryRecord(
            HistoryRecordId id,
            DateTime date,
            FertilizerType fertilizerType,
            Amount amount

        ) : base(id, date)
        {
            FertilizerType = fertilizerType;
            Amount = amount;
        }
    }
}
