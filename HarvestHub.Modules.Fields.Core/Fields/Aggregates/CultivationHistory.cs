﻿using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    internal class CultivationHistory : AggregateRoot<CultivationHistoryId>
    {
        protected List<HistoryRecord> _history = new List<HistoryRecord>();
        public IReadOnlyList<HistoryRecord> History => _history.AsReadOnly();

        public CultivationHistory(CultivationHistoryId id) : base(id) { }

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