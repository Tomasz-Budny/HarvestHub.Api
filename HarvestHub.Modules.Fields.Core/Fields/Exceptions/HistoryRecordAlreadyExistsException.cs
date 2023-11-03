using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    public class HistoryRecordAlreadyExistsException : HarvestHubException
    {
        public Guid HistoryRecordId { get; set; }
        public HistoryRecordAlreadyExistsException(Guid historyRecordId) : base($"history record with provided id {historyRecordId} already exists!")
        {
            HistoryRecordId = historyRecordId;
        }
    }
}
