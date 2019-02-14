using System;
using BuildingBlocks.Extensions.MongoDB.builders;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    public static class MongoServicesExtensions
    {
        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            Action<MongoConfigurationBuilder> builder)
        {
            var configuration = new MongoConfigurationBuilder();
            builder(configuration);

            if (configuration.DatabaseName == null)
                throw new ArgumentNullException("Не задано имя базы данных");

            if (configuration.ConfigureDatabaseSettings == null)
                throw new ArgumentNullException(
                    "Конфигурация подключения к серверу MongoDB не может быть пустой");

            var clientSettings = new MongoClientSettings();
            configuration.ConfigureClientSettings?.Invoke(clientSettings);

            if (clientSettings.Server == null) 
                throw new ArgumentNullException("Не задана строка подключения");

            var databaseSettings = new MongoDatabaseSettings();
            configuration.ConfigureDatabaseSettings?.Invoke(databaseSettings);

            var client = new MongoClient(clientSettings);
            var database = client.GetDatabase(configuration.DatabaseName, databaseSettings);

            services.AddSingleton(database);

            return services;
        }
    }
}
