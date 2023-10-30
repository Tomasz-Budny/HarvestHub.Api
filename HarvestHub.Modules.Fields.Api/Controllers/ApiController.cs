using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Fields.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly ISender _sender;

        protected ApiController(ISender sender)
        {
            _sender = sender;
        }
    }
}
