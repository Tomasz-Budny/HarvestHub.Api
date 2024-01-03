using HarvestHub.Modules.Fields.Application.Owners.Commands.UpdateStartLocation;
using HarvestHub.Modules.Fields.Application.Owners.Dtos;
using HarvestHub.Modules.Fields.Application.Owners.Queries;
using HarvestHub.Shared.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [Route("api/owners")]
    public class OwnerController : ApiController
    {
        public OwnerController(ISender sender, IUserContextService userContextService) : base(sender, userContextService) { }

        [HttpPost("start_location")]
        public async Task<ActionResult> UpdateStartLocation(UpdateStartLocationRequest request, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var command = new UpdateStartLocationCommand(ownerId, request.Point);

            await _sender.Send(command, cancellationToken);

            return Ok();
        }

        [HttpGet("start_location")]
        public async Task<ActionResult<StartLocationDto>> GetStartLocation(CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var startLocation = await _sender.Send(new GetOwnerStartLocationQuery(ownerId), cancellationToken);

            return Ok(startLocation);
        }
    }
}
