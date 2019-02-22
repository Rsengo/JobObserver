using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Extensions.MongoDB;
using BrandedTemplates.Db;

namespace BrandedTemplates.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateMongoDbContext<BrandedTemplatesDbContext>((_, __) => { })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((ctx, services) =>
                {
                    services.AddMongoContext<BrandedTemplatesDbContext>(builder =>
                    {
                        builder.ConnectionString = ctx.Configuration.GetSection("MongoDB")["ConnectionString"];
                        builder.DatabaseName = ctx.Configuration.GetSection("MongoDB")["Database"];
                        builder.MigrationsAssembly = typeof(BrandedTemplatesDbContext).Assembly;
                    });
                })
                .Build();
    }
}
