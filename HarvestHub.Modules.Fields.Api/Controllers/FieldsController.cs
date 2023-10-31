using Microsoft.AspNetCore.Mvc;
using HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField;
using MediatR;
using HarvestHub.Modules.Fields.Application.Fields.Queries;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/fields")]
    public class FieldsController : ApiController
    {
        public FieldsController(ISender sender) : base(sender) { }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFieldCommand dto, CancellationToken cancellationToken)
        {
            await _sender.Send(dto, cancellationToken);

            return CreatedAtAction(nameof(Get), null);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var field = await _sender.Send(new GetFieldQuery(id), cancellationToken);

            return Ok(field);
        }
    }
}
