using HarvestHub.Modules.Notifications.Api.Services;
using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Notifications.Api.Handlers.Users
{
    internal sealed class ForgetPasswordHandler : IEventHandler<ForgetPassword>
    {
        private readonly ISmtpService _smtpService;
        public ForgetPasswordHandler(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }
        public Task HandleAsync(ForgetPassword @event, CancellationToken cancellationToken = default)
         => _smtpService.SendForgetPasswordEmail(@event.Email, @event.Name, @event.ResetPasswordToken);
    }
}
