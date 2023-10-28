using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Modules.Users.Core.Dtos
{
    public record ChangePasswordDto(string Email, Guid ResetPasswordToken, [FromBody] string NewPassword);
}
