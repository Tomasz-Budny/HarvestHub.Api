using HarvestHub.Modules.Users.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Users.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<IHashingService, HashingService>();

            return services;
        }
    }
}
