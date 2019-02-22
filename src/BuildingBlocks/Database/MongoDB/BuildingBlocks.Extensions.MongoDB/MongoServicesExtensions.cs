using System;
using BuildingBlocks.Extensions.MongoDB.builders;
using BuildingBlocks.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    using global::MongoDB.Bson.Serialization.Conventions;

    public static class MongoServicesExtensions
    {
        public static IServiceCollection AddMongoContext<TContext>(
            this IServiceCollection services,
            Action<MongoConfigurationBuilder> builder)
            where TContext : MongoDbContext
        {
            var configuration = new MongoConfigurationBuilder();
            builder(configuration);

            if (configuration.DatabaseName == null)
                throw new ArgumentNullException("Не задано имя базы данных");

            var clientSettings = string.IsNullOrEmpty(configuration.ConnectionString)
                ? new MongoClientSettings()
                : MongoClientSettings.FromConnectionString(configuration.ConnectionString);
            configuration.ConfigureClientSettings?.Invoke(clientSettings);

            if (clientSettings.Server == null)
                throw new ArgumentNullException("Не заданы настройки подключения к серверу БД");

            var databaseSettings = new MongoDatabaseSettings();
            configuration.ConfigureDatabaseSettings?.Invoke(databaseSettings);

            if (configuration.CamelCase)
            {
                var conventionPack = new ConventionPack();
                var camelCaseConvention = new CamelCaseElementNameConvention();
                conventionPack.Add(camelCaseConvention);
                ConventionRegistry.Register("camelCase", conventionPack, t => true);
            }

            services.AddScoped(provider =>
            {
                var client = new MongoClient(clientSettings);
                var database = client.GetDatabase(configuration.DatabaseName, databaseSettings);
                var context = (TContext) Activator.CreateInstance(typeof(TContext), database);

                if (configuration.MigrationsAssembly != null)
                    context.MigrationsAssembly = configuration.MigrationsAssembly;

                return context;
            });

            return services;
        }
    }
}
