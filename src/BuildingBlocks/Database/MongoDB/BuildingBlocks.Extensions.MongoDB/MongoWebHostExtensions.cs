using System;
using BuildingBlocks.MongoDB;
using BuildingBlocks.MongoDB.Migration;
using global::MongoDB.Driver;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Extensions.MongoDB
{
    public static class MongoWebHostExtensions
    {
        public static IWebHost MigrateMongoDbContext<TContext>(
            this IWebHost webHost, 
            Action<TContext, IServiceProvider> seeder)
            where TContext : MongoDbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    var retry = Policy.Handle<MongoException>()
                        .WaitAndRetry(new []
                        {
                            TimeSpan.FromSeconds(3),
                            TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(8),
                        });

                    retry.Execute(() => InvokeSeeder(seeder, context, services));

                    logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex,
                        $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }

        private static void InvokeSeeder<TContext>(
            Action<TContext, IServiceProvider> seeder, 
            TContext context, 
            IServiceProvider services)
            where TContext : MongoDbContext
        {
            context.MigrateUp();
            seeder(context, services);
        }
    }
}
