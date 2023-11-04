using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord
{
    internal class AddHarvestHistoryRecordCommandHandler : ICommandHandler<AddHarvestHistoryRecordCommand>
    {
        private readonly ICultivationHistoryRepository _historyRepository;

        public AddHarvestHistoryRecordCommandHandler(ICultivationHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task Handle(AddHarvestHistoryRecordCommand request, CancellationToken cancellationToken)
        {
            var (cultivationHistoryId, ownerId, historyRecordId, date, amount, cropType, humidity) = request;

            var history = await _historyRepository.GetAsync(cultivationHistoryId, ownerId, cancellationToken);

            if (history is null)
            {
                throw new CultivationHistoryNotFoundException(cultivationHistoryId);
            }

            var harvestHistoryRecord = new HarvestHistoryRecord(
                historyRecordId,
                date,
                amount,
                cropType,
                humidity);

            history.Add(harvestHistoryRecord);

            await _historyRepository.UpdateAsync(history, cancellationToken);
        }
    }
}
