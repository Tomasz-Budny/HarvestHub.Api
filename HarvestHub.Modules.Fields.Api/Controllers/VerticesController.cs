using HarvestHub.Modules.Fields.Application.Fields.Commands.InsertVertices;
using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/fields/{fieldId:guid}/vertices")]
    public class VerticesController : ApiController
    {
        public VerticesController(ISender sender) : base(sender) { }
        [HttpPost("insert")]
        public async Task<ActionResult> Insert([FromRoute] Guid fieldId, [FromBody] InsertVerticesRequest request, CancellationToken cancellationToken)
        {
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new InsertVerticesCommand(fieldId, ownerId, request.Vertices), cancellationToken);

            return Ok();
        }
    }
}
