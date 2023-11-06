using HarvestHub.Modules.Fields.Infrastructure.Persistance;
using HarvestHub.Shared.Database.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Modules.Fields.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using HarvestHub.Modules.Fields.Application.Services;
using HarvestHub.Modules.Fields.Infrastructure.Services;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Services;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Modules.CultivationHistories.Infrastructure.Persistance.Services;

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
            services.AddScoped<ICultivationHistoryRepository, CultivationHistoryRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<ICultivationHistoryService, CultivationHistoryService>();

            var smtpOtions = configuration.GetOptions<GoogleApiOptions>(GoogleApiOptions.SectionName);
            services.AddSingleton(Options.Create(smtpOtions));

            services.AddScoped<IAddressService, AddressService>();

            services.AddHttpClient<IAddressService, AddressService>((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri($"https://maps.googleapis.com/maps/api/geocode/");
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "pl-PL,pl;q=0.9,en-US;q=0.8,en;q=0.7");
            });

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(Extensions).Assembly);
            });

            return services;
        }
    }
}
