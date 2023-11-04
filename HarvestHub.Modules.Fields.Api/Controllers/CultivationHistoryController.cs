﻿using HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/fields/{fieldId:guid}/history")]
    public class CultivationHistoryController : ApiController
    {
        public CultivationHistoryController(ISender sender) : base(sender) { }

        [HttpPost("harvest")]
        public async Task<ActionResult> AddHarvestHistoryRecord([FromRoute] Guid fieldId, [FromBody] AddHarvestHistoryRecordRequest request, CancellationToken cancellationToken)
        {
            var (date, amount, cropType, humidity) = request;
            // change to context service
            var ownerId = new Guid();

            var historyRecordId = Guid.NewGuid();

            await _sender.Send(
                new AddHarvestHistoryRecordCommand(
                    fieldId,
                    ownerId,
                    historyRecordId,
                    date,
                    amount,
                    cropType,
                    humidity), cancellationToken);

            return Created("Get", new { Id = historyRecordId });
        }
    }
}