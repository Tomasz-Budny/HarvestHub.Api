using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Modules.Fields.Application;
using Microsoft.Extensions.Configuration;
using HarvestHub.Modules.Fields.Infrastructure;

namespace HarvestHub.Modules.Fields.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddFieldsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
