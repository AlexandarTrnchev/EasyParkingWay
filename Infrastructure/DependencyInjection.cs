using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            configuration.GetConnectionString("DefaultConnection"),
            //                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            //        ), ServiceLifetime.Transient);

            //services.AddAuthentication(AzureADDefaults.JwtBearerAuthenticationScheme)
            //    .AddAzureADBearer(options => configuration.Bind("AzureAd", options));

            IdentityModelEventSource.ShowPII = true;

            services.AddTransient<IIdentityService, IdentityService>();
                    //.AddTransient<IQueryService, QueryService>()
                    //.AddTransient<QueryBuilder>()
                    //.AddTransient<IGraphApiService, GraphApiService>();

            return services;
        }
    }
}
