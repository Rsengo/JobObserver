using System;
using System.Linq;
using System.Reflection;
using BuildingBlocks.Database.MongoDB.Configuration;
using BuildingBlocks.Database.MongoDB.Mapping;
using BuildingBlocks.Database.MongoDB.Models;
using BuildingBlocks.Extensions.Assemblies;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    public static class MongoServicesExtensions
    {
        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            string databaseName,
            Action<MongoClientSettings> clientSettingsBuilder,
            Action<MongoDatabaseSettings> databaseSettingsBuilder = null)
        {
            if (databaseName == null)
                throw new ArgumentNullException("Не задано имя базы данных");

            if (clientSettingsBuilder == null)
                throw new ArgumentNullException(
                    "Конфигурация подключения к серверу MongoDB не может быть пустой");

            var clientSettings = new MongoClientSettings();
            clientSettingsBuilder(clientSettings);

            if (clientSettings.Server == null) 
                throw new ArgumentNullException("Не задана строка подключения");

            var databaseSettings = new MongoDatabaseSettings();
            databaseSettingsBuilder?.Invoke(databaseSettings);

            var client = new MongoClient(clientSettings);
            var database = client.GetDatabase(databaseName, databaseSettings);

            services.AddSingleton(database);

            return services;
        }

        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            string connectionString,
            string databaseName,
            Action<MongoDatabaseSettings> databaseSettingsBuilder = null)
        {
            if (databaseName == null)
                throw new ArgumentNullException("Не задано имя базы данных");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(
                    "Строка подключения к серверу MongoDB не может быть пустой");

            var databaseSettings = new MongoDatabaseSettings();
            databaseSettingsBuilder?.Invoke(databaseSettings);

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName, databaseSettings);

            services.AddSingleton(database);

            return services;
        }
    }
}
