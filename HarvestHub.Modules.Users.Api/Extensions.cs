using HarvestHub.Modules.Users.Core;
using HarvestHub.Modules.Users.Dal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Users.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessLayer(configuration);
            services.AddCore();

            return services;
        }
    }
}
