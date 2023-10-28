using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Users.Shared.Events
{
    public record ForgetPassword(string Email, string Name, Guid ResetPasswordToken) : IEvent;
}
