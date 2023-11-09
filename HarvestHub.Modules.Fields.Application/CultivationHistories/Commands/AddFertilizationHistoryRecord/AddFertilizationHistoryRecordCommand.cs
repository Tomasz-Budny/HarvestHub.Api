using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddFertilizationHistoryRecord
{
    public record AddFertilizationHistoryRecordCommand(
        Guid FieldId,
        Guid OwmerId,
        Guid HistoryRecordId,
        DateTime Date,
        double Amount,
        FertilizerType FertilizerType

    ) : ICommand;
}
