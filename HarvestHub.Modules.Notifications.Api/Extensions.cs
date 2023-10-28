using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using HarvestHub.Modules.Notifications.Api.Options;

namespace HarvestHub.Modules.Notifications.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection services, IConfiguration configuration)
        {
            var smtpOtions = configuration.GetOptions<SmtpOptions>(SmtpOptions.SectionName);
            services.AddSingleton(Microsoft.Extensions.Options.Options.Create(smtpOtions));

            return services;
        }
    }
}
