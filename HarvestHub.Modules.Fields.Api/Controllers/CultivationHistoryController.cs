using HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddFertilizationHistoryRecord;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Commands.DeleteHistoryRecord;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/fields/{fieldId:guid}/history")]
    public class CultivationHistoryController : ApiController
    {
        public CultivationHistoryController(ISender sender) : base(sender) { }

        [HttpPost("harvest")]
        public async Task<ActionResult> AddHarvestHistoryRecord([FromRoute] Guid fieldId, [FromBody] AddHarvestHistoryRecordByFieldIdRequest request, CancellationToken cancellationToken)
        {
            var (date, amount, cropType, humidity) = request;
            // change to context service
            var ownerId = new Guid();

            var historyRecordId = Guid.NewGuid();

            await _sender.Send(
                new AddHarvestHistoryRecordByFieldIdCommand(
                    fieldId, 
                    ownerId,
                    historyRecordId,
                    date,
                    amount,
                    cropType,
                    humidity), cancellationToken);

            return CreatedAtAction(nameof(GetHarvestHistoryRecords), new { FieldId = fieldId }, new { Id = historyRecordId });
        }

        [HttpGet("harvest")]
        public async Task<ActionResult<IEnumerable<HarvestHistoryRecordDto>>> GetHarvestHistoryRecords([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            // change to context service
            var ownerId = new Guid();

            var records = await _sender.Send(new GetHarvestHistoryRecordsByFieldIdQuery(fieldId, ownerId), cancellationToken);

            return Ok(records);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryRecordDto>>> GetAllHistoryRecords([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            // change to context service
            var ownerId = new Guid();

            var records = await _sender.Send(new GetAllHistoryRecordsByFieldIdQuery(fieldId, ownerId), cancellationToken);

            return Ok(records);
        }

        [HttpDelete("{historyRecordId:guid}")]
        public async Task<ActionResult<IEnumerable<HistoryRecordDto>>> DeleteHistoryRecord([FromRoute] Guid fieldId, Guid historyRecordId, CancellationToken cancellationToken)
        {
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new DeleteHistoryRecordCommand(fieldId, ownerId, historyRecordId), cancellationToken);

            return NoContent();
        }

        [HttpPost("fertilization")]
        public async Task<ActionResult> AddFertilizationHistoryRecord([FromRoute] Guid fieldId, [FromBody] AddFertilizationHistoryRecordByFieldIdRequest request, CancellationToken cancellationToken)
        {
            var (date, amount, fertilizerType) = request;
            // change to context service
            var ownerId = new Guid();

            var historyRecordId = Guid.NewGuid();

            await _sender.Send(
                new AddFertilizationHistoryRecordCommand(
                    fieldId,
                    ownerId,
                    historyRecordId,
                    date,
                    amount,
                    fertilizerType
                    ), cancellationToken);

            return CreatedAtAction(nameof(GetHarvestHistoryRecords), new { FieldId = fieldId }, new { Id = historyRecordId });
        }
    }
}
