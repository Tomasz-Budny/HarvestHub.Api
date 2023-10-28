using HarvestHub.Modules.Users.Dal.Authentication;
using HarvestHub.Shared.Authentication;
using HarvestHub.Shared.Events;
using HarvestHub.Shared.Exceptions;
using HarvestHub.Shared.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddEvents();
            services.AddMessaging();
            services.AddScoped<ErrorHandlerMiddleware>();
            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();

            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();
            return services;
        }

        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName) where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }
    }
}
