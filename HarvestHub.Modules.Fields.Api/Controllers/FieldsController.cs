﻿using Microsoft.AspNetCore.Mvc;
using HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField;
using MediatR;
using HarvestHub.Modules.Fields.Application.Fields.Queries;
using HarvestHub.Modules.Fields.Application.Fields.Dtos;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/fields")]
    public class FieldsController : ApiController
    {
        public FieldsController(ISender sender) : base(sender) { }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFieldRequest request, CancellationToken cancellationToken)
        {
            var (name, center, area, color, vertices) = request;
            var fieldId = Guid.NewGuid();
            // change to context service
            var ownerId = new Guid();

            await _sender.Send(new CreateFieldCommand(fieldId, ownerId, name, center, area, color, vertices), cancellationToken);

            return CreatedAtAction(nameof(Get), new { Id = fieldId }, null);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var field = await _sender.Send(new GetFieldQuery(id), cancellationToken);

            return Ok(field);
        }
    }
}
