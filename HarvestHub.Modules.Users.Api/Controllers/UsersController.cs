﻿using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;

        public UsersController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserDto dto)
        {
            var userId = await _usersService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetByEmail), new { userId }, null);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            var userDto = await _usersService.GetByEmail(email);

            return Ok(userDto);
        }

        [HttpPost("verify")]
        public async Task<ActionResult> Verify([FromQuery] Guid verificationToken)
        {
            await _usersService.Verify(verificationToken);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto dto)
        {
            var token = await _usersService.Login(dto);

            return Ok(token);
        }

        [HttpPost("forget_password")]
        public async Task<ActionResult<string>> ForgetPassword(string email)
        {
            await _usersService.ForgetPassword(email);

            return Ok();
        }

        [HttpPost("change_password")]
        public async Task<ActionResult<string>> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            await _usersService.ChangePassword(dto);

            return Ok();
        }

        [HttpGet("email_unique")]
        public async Task<ActionResult<bool>> IsEmailUnique([FromQuery] string email)
        {
            var isUnique = await _usersService.IsEmailUnique(email);

            return Ok(isUnique);
        } 
    }
}
