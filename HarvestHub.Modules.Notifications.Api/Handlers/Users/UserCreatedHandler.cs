using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Events;
using Microsoft.Extensions.Logging;

namespace HarvestHub.Modules.Notifications.Api.Handlers.Users
{
    internal sealed class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly ILogger<UserCreatedHandler> _logger;
        public UserCreatedHandler(ILogger<UserCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"user email {@event.Email}");
            _logger.LogInformation($"user email {@event.Email}");

            return Task.CompletedTask;
        }
    }
}
