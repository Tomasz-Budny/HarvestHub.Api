using HarvestHub.Shared.Database.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Modules.Users.Dal.Persistance;

namespace HarvestHub.Modules.Users.Dal
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>(SqlOptions.SectionName);
            services.AddDbContext<UsersDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
