using Application.Common.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyParkingWay
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host;
            try
            {
                 host = CreateHostBuilder(args).Build();

            }
            catch (Exception ex )
            {

                throw;
            }

            //Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
            //.WriteTo.File("logs/log.txt",
            //restrictedToMinimumLevel: LogEventLevel.Error,
            //   rollingInterval: RollingInterval.Day,
            //   fileSizeLimitBytes: 268435456, //250MB
            //   rollOnFileSizeLimit: true)
            //.CreateLogger();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }

                    await ApplicationDbContextSeed.Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
