using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;

        public UsersController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreateUserDto dto)
        {
            var userId = await _usersService.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { userId }, null);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            var userDto = await _usersService.GetByEmail(email);

            return Ok(userDto);
        }
    }
}
