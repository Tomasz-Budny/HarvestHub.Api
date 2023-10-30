using Microsoft.AspNetCore.Mvc;
using HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField;
using MediatR;

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

            return Ok();
        }
    }
}
