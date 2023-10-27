using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Users.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
