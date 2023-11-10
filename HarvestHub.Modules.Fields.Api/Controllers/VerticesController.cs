﻿using HarvestHub.Modules.Fields.Application.Fields.Commands.InsertVertices;
using HarvestHub.Modules.Fields.Application.Fields.Commands.ReplaceVertices;
using HarvestHub.Modules.Fields.Application.Fields.Commands.UpdateVertices;
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
            var (verticesDto, area) = request;
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new InsertVerticesCommand(fieldId, ownerId, verticesDto, area), cancellationToken);

            return Ok();
        }

        [HttpPost("replace")]
        public async Task<ActionResult> Replace([FromRoute] Guid fieldId, [FromBody] ReplaceVerticesRequest request, CancellationToken cancellationToken)
        {
            var (verticesDto, area, pointDto) = request;
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new ReplaceVerticesCommand(fieldId, ownerId, verticesDto, area, pointDto), cancellationToken);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromRoute] Guid fieldId, [FromBody] UpdateVerticesRequest request, CancellationToken cancellationToken)
        {
            var (verticesDto, area, pointDto) = request;
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new UpdateVerticesCommand(fieldId, ownerId, verticesDto, area, pointDto), cancellationToken);

            return Ok();
        }
    }
}
