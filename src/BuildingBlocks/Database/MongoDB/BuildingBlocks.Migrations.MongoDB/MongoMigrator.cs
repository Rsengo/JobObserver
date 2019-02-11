using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MongoDB.Driver;

namespace BuildingBlocks.Migrations.MongoDB
{
    public sealed class MongoMigrator
    {
        /// <summary>
        /// Инстанс
        /// </summary>
        private static MongoMigrator _instance;

        /// <summary>
        /// Локкер
        /// </summary>
        private static readonly object _syncRoot = new object();

        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private MongoMigrator() { }

        /// <summary>
        /// Получение инстанса
        /// </summary>
        public static MongoMigrator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new MongoMigrator();
                    }
                }
                return _instance;
            }
        }

        public void MigrateUp(
            IMongoDatabase database, 
            Assembly migrationAssembly)
        {
            var migrationVersionDictionary = GetMigrationDictionary(database, migrationAssembly);

            var sortedMigrationVersionDictionary = migrationVersionDictionary.OrderBy(x => long.Parse(x.Key));

            foreach (var pair in sortedMigrationVersionDictionary)
            {
                var migration = pair.Value;
                migration.Up();
            }

            var versionCollection = database.GetCollection<MongoVersionInfo>(nameof(MongoVersionInfo));
            if (versionCollection.)
        }

        public void MigrateDown(
            IMongoDatabase database, 
            Assembly migrationAssembly, 
            string downVersion)
        {
            var migrationVersionDictionary = GetMigrationDictionary(database, migrationAssembly);

            var sortedMigrationVersionDictionary = migrationVersionDictionary
                .OrderBy(x => long.Parse(x.Key))
                .Where(x => long.Parse(x.Key) > long.Parse(downVersion));

            foreach (var pair in sortedMigrationVersionDictionary)
            {
                var migration = pair.Value;
                migration.Down();
            }
        }

        public void MigrateDown(
            IMongoDatabase database,
            Assembly migrationAssembly,
            DateTime versionTime)
        {
            var day = versionTime.Day.ToString().PadLeft(2);
            var month = versionTime.Month.ToString().PadLeft(2);
            var year = versionTime.Year.ToString();
            var hour = versionTime.Hour.ToString().PadLeft(2);
            var minute = versionTime.Minute.ToString().PadLeft(2);
            var second = versionTime.Second.ToString().PadLeft(2);

            var version = string.Concat(year, month, day, hour, minute, second);

            MigrateDown(database, migrationAssembly, version);
        }

        private static IDictionary<string, MongoMigration> GetMigrationDictionary(
            IMongoDatabase database, 
            Assembly migrationAssembly)
        {
            var migrationType = typeof(MongoMigration);
            var migrations = migrationAssembly.GetTypes().Where(x => x.IsSubclassOf(migrationType));

            var migrationVersionDictionary = new Dictionary<string, MongoMigration>();

            foreach (var migration in migrations)
            {
                var attributes = migration.GetCustomAttributes(false);
                var versionAttribute = attributes.SingleOrDefault(x => x is MongoMigrationAttribute);

                if (versionAttribute == null)
                    throw new CustomAttributeFormatException($"Не задана версия миграции для { migration.Name }");

                var version = ((MongoMigrationAttribute)versionAttribute).Version;
                var typedMigration = (MongoMigration)Activator.CreateInstance(migration, database);

                migrationVersionDictionary.Add(version, typedMigration);
            }

            return migrationVersionDictionary;
        }
    }
}
