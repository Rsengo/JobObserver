using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB.builders
{
    public sealed class MongoConfigurationBuilder
    {
        internal Action<MongoClientSettings> ConfigureClientSettings { get; private set; }
        internal Action<MongoDatabaseSettings> ConfigureDatabaseSettings { get; private set; }
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
    }
}
