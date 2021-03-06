﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB.Builders
{
    public sealed class MongoConfigurationBuilder
    {
        internal Action<MongoClientSettings> ConfigureClientSettings { get; private set; }

        internal Action<MongoDatabaseSettings> ConfigureDatabaseSettings { get; private set; }

        internal bool CamelCase { get; private set; }

        public Assembly MigrationsAssembly { get; set; }

        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }

        public MongoConfigurationBuilder()
        {
            CamelCase = false;
        }

        public void ConfigureClient(Action<MongoClientSettings> settings)
        {
            ConfigureClientSettings = settings;
        }

        public void ConfigureDatabase(Action<MongoDatabaseSettings> settings)
        {
            ConfigureDatabaseSettings = settings;
        }

        public void UseCamelCase()
        {
            CamelCase = true;
        }
    }
}
