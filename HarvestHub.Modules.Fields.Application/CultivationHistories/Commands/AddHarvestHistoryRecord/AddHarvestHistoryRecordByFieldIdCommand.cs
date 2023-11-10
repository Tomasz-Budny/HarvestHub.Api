using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord
{
    public record AddHarvestHistoryRecordByFieldIdCommand(
        Guid FieldId,
        Guid OwmerId,
        Guid HistoryRecordId,
        DateTime Date,
        double Amount, 
        CropType CropType, 
        uint Humidity

    ) : ICommand;
}
