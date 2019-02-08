using System;
using System.Linq;
using System.Reflection;
using BuildingBlocks.Database.MongoDB.Mapping;
using BuildingBlocks.Database.MongoDB.Models;
using BuildingBlocks.Extensions.Assemblies;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    public static class MongoServicesExtensions
    {
        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            string databaseName,
            MongoClientSettings clientSettings = null,
            MongoDatabaseSettings databaseSettings = null)
        {
            var client = new MongoClient(clientSettings);
            var database = client.GetDatabase(databaseName, databaseSettings);

            services.AddSingleton(database);

            var assembly = Assembly.GetCallingAssembly();
            var assemblyTree = assembly.LoadAssembliesTree();

            var classMapType = typeof(MongoClassMap<>);
            foreach (var assemblyInfo in assemblyTree)
            {
                var maps = assemblyInfo.GetTypes()
                    .Where(x => x.IsSubclassOf(classMapType));

                var instances = maps.Select(x => Activator.CreateInstance<>());
            }

            return services;
        }
    }
}
