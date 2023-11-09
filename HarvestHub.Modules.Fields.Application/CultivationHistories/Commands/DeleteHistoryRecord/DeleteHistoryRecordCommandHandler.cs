using HarvestHub.Modules.Fields.Application.CultivationHistories.Services;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.DeleteHistoryRecord
{
    internal class DeleteHistoryRecordCommandHandler : ICommandHandler<DeleteHistoryRecordCommand>
    {
        private readonly ICultivationHistoryService _historyService;
        private readonly ICultivationHistoryRepository _historyRepository;

        public DeleteHistoryRecordCommandHandler(ICultivationHistoryService historyService, ICultivationHistoryRepository cultivationHistoryRepository)
        {
            _historyService = historyService;
            _historyRepository = cultivationHistoryRepository;
        }
        public async Task Handle(DeleteHistoryRecordCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, historyRecordId) = request;

            var history = await _historyService.GetByFieldId(fieldId, ownerId, cancellationToken);

            history.Remove(historyRecordId);

            await _historyRepository.UpdateAsync(history, cancellationToken);
        }
    }
}
