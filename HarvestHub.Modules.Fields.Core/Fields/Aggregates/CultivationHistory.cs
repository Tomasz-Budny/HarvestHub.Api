using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    public class CultivationHistory : AggregateRoot<CultivationHistoryId>
    {
        public OwnerId OwnerId { get; }

        protected List<HistoryRecord> _history = new();
        public IReadOnlyList<HistoryRecord> History => _history.AsReadOnly();

        public CultivationHistory(CultivationHistoryId id, OwnerId ownerId) : base(id) 
        {
            OwnerId = ownerId;
        }

        public void Add(HistoryRecord newHistoryRecord)
        {
            var alreadyExists = _history.Any(historyRecord => historyRecord == newHistoryRecord);
            if(alreadyExists)
            {
                throw new HistoryRecordAlreadyExistsException(newHistoryRecord.Id);
            }

            _history.Add(newHistoryRecord);
        }

        public void Remove(HistoryRecordId historyRecordId)
        {
            var historyRecord = _history.Find(historyRecord => historyRecord.Id == historyRecordId);

            if(historyRecord is null)
            {
                throw new HistoryRecordNotExistException(historyRecordId);
            }
         
            _history.Remove(historyRecord);
        }
    }
}
