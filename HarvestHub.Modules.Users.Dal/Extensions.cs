using HarvestHub.Shared.Database.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Modules.Users.Dal.Persistance;
using HarvestHub.Modules.Users.Dal.Authentication.Options;
using Microsoft.Extensions.Options;
using HarvestHub.Modules.Users.Dal.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HarvestHub.Shared.Authentication;

namespace HarvestHub.Modules.Users.Dal
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>(SqlOptions.SectionName);
            services.AddDbContext<UsersDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            services.AddAuth(configuration);

            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetOptions<JwtOptions>(JwtOptions.SectionName);
            services.AddSingleton(Options.Create(jwtOptions));

            var usersOptions = configuration.GetOptions<UsersOptions>(UsersOptions.SectionName);
            services.AddSingleton(Options.Create(usersOptions));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Secret))
                });

            return services;
        }
    }
}
