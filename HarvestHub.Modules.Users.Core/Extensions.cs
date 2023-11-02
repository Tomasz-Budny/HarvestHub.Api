using HarvestHub.Modules.Users.Core.Services;
using HarvestHub.Shared.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HarvestHub.Modules.Users.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<IHashingService, HashingService>();

            services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
