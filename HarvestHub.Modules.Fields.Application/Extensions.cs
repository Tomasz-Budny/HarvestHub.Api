using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Modules.Fields.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(Extensions).Assembly);
            });

            return services;
        }
    }
}
