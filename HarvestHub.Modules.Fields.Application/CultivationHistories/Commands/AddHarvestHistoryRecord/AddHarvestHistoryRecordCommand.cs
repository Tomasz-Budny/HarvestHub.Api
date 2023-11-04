
using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord
{
    public record AddHarvestHistoryRecordCommand(
        Guid CultivationHistoryId, 
        Guid OwnerId,
        Guid HistoryRecordId,
        DateTime Date,
        double Amount, 
        CropType CropType, 
        uint Humidity

    ) : ICommand;
}
