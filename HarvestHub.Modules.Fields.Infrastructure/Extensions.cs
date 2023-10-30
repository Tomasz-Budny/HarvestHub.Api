using HarvestHub.Modules.Fields.Infrastructure.Persistance;
using HarvestHub.Shared.Database.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories;

namespace HarvestHub.Modules.Fields.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>(SqlOptions.SectionName);
            services.AddDbContext<FieldsDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            services.AddScoped<IFieldRepository, FieldRepository>();

            return services;
        }
    }
}
