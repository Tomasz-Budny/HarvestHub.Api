using HarvestHub.Modules.Fields.Core.CultivationHistories.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.CultivationHistories.Entities
{
    public abstract class HistoryRecord : Entity<HistoryRecordId>
    {
        public DateTime Date { get; set; }

        protected HistoryRecord(HistoryRecordId id, DateTime date) : base(id)
        {
            Date = date;
        }
    }
}
