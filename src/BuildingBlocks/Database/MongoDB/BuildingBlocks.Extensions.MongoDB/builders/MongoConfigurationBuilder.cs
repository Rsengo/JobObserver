using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB.builders
{
    public sealed class MongoConfigurationBuilder: IDisposable
    {
        private const string MIGRATION_DOMAIN_NAME = "Mongo Migrations Domain";

        private AppDomain _migrationsDomain;

        internal Action<MongoClientSettings> ConfigureClientSettings { get; private set; }

        internal Action<MongoDatabaseSettings> ConfigureDatabaseSettings { get; private set; }

        internal Assembly MigrationsAssembly { get; private set; }

        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }

        public void ConfigureClient(Action<MongoClientSettings> settings)
        {
            ConfigureClientSettings = settings;
        }

        public void ConfigureDatabase(Action<MongoDatabaseSettings> settings)
        {
            ConfigureDatabaseSettings = settings;
        }

        public void UseMigrationsAssembly(string friendlyAssemblyName)
        {
            _migrationsDomain = AppDomain.CreateDomain(MIGRATION_DOMAIN_NAME);
            MigrationsAssembly = _migrationsDomain.Load(friendlyAssemblyName);
        }

        public void UseMigrationsAssembly(Assembly assembly)
        {
            MigrationsAssembly = assembly;
        }

        public void Dispose()
        {
            if (_migrationsDomain == null) 
                return;

            AppDomain.Unload(_migrationsDomain);
        }
    }
}
