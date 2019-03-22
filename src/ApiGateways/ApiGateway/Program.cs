﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);
            var configPath = Path.Combine("configuration", "configuration.json");

            builder.ConfigureServices(s => s.AddSingleton(builder))
                .ConfigureAppConfiguration(ic => ic.AddJsonFile(configPath))
                .UseStartup<Startup>();

            var host = builder.Build();
            return host;
        }
    }
}
