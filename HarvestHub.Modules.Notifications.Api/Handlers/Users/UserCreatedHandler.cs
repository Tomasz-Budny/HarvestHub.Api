using HarvestHub.Modules.Notifications.Api.Services;
using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Notifications.Api.Handlers.Users
{
    internal sealed class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly ISmtpService _smtpService;
        public UserCreatedHandler(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        public Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
            =>  _smtpService.SendConfirmationEmail(@event.Email, @event.FirstName, @event.VerificationToken);
    }
}
