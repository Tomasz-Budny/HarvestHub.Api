using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Entities
{
    public abstract class HistoryRecord : Entity<HistoryRecordId>
    {
        public FieldId FieldId { get; set; }
        public DateTime Date { get; set; }

        protected HistoryRecord(HistoryRecordId id, FieldId fieldId, DateTime date) : base(id)
        {
            FieldId = fieldId;
            Date = date;
        }
    }
}
