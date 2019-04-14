using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Extensions.EntityFramework;
using Dictionaries.Db;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dictionaries.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<DictionariesDbContext>()
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
                    var LogFolder = builderContext.Configuration["LogFolder"];
                    var filePath = Path.Combine(builderContext.HostingEnvironment.ContentRootPath, LogFolder, "Dictionaries.txt");
                    config
                        .MinimumLevel.Information()
                        .Enrich.FromLogContext()
                        .WriteTo.ColoredConsole()
                        .WriteTo.File(filePath);
                    // .WriteTo.Elasticsearch(url);
                })
                .Build();
    }
}
