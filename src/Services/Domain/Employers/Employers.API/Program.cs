using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Extensions.EntityFramework;
using Employers.Db;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Employers.API.Data;

namespace Employers.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<EmployersDbContext>((context, sp) =>
                {
                    var logger = sp.GetService<ILogger<EmployersDbContextSeed>>();
                    new EmployersDbContextSeed()
                        .SeedAsync(context, logger)
                        .Wait();
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((_, configBuilder) =>
                {
                    configBuilder.AddEnvironmentVariables();
                    configBuilder.Build();
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .UseSerilog((builderContext, config) =>
                {
                    var url = builderContext.Configuration["ElasticSearch"];
                    var seqUrl = builderContext.Configuration["Seq"];
                    config
                        .MinimumLevel.Information()
                        .Enrich.FromLogContext()
                        .WriteTo.ColoredConsole()
                        //.WriteTo.Elasticsearch(url)
                        .WriteTo.Seq(seqUrl);
                })
                .Build();
    }
}
