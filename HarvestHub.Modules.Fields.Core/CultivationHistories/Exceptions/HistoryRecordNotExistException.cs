using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.CultivationHistories.Exceptions
{
    internal class HistoryRecordNotExistException : HarvestHubException
    {
        public Guid HistoryRecordId { get; set; }
        public HistoryRecordNotExistException(Guid historyRecordId) : base($"history record with provided id {historyRecordId} does not exist!")
        {
            HistoryRecordId = historyRecordId;
        }
    }
}
