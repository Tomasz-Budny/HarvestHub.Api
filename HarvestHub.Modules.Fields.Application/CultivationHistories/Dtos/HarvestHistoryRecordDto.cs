﻿using HarvestHub.Modules.Fields.Core.Fields.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record HarvestHistoryRecordDto(
        Guid HistoryRecordId,
        DateTime Date,
        CropType CropType,
        double Amount,
        uint Humidity
    );
}
