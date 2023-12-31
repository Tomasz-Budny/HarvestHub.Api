﻿using HarvestHub.Modules.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos
{
    public record UpdateHarvestHistoryRecordRequest(
        DateTime Date,
        CropType CropType,
        double Amount,
        uint Humidity
    );
}
