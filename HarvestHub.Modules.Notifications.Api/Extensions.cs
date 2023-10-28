using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Notifications.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
