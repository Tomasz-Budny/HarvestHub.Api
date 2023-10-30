using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Modules.Fields.Application;

namespace HarvestHub.Modules.Fields.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddFieldsModule(this IServiceCollection services)
        {
            services.AddApplication();

            return services;
        }
    }
}
