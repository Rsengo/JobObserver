using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BuildingBlocks.MongoDB.Filters;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BuildingBlocks.MongoDB.Migration
{
    internal sealed class MongoMigrator
    {
        private const string VERSION_INFO_COLLECTION = "VersionInfo";
        private const string MIGRATIONS_DOMAIN = "mongo migrations domain";

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

        public void MigrateUp(MongoDbContext context)
        {
            AppDomain domain = null;

            try
            {
                if (string.IsNullOrWhiteSpace(context.MigrationsAssembly))
                {
                    throw new NullReferenceException("Не указана сборка с миграциями");
                }

                domain = AppDomain.CreateDomain(MIGRATIONS_DOMAIN);
                var migrationsAssembly = domain.Load(context.MigrationsAssembly);

                context.ExecuteTransaction(database =>
                {
                    var migrationData = GetMigrationsInfo(database, migrationsAssembly);
                    var sortedMigrationData = migrationData.OrderBy(x => long.Parse(x.Version));

                    var collectionExists = GetVersionCollectionExists(database);

                    if (!collectionExists)
                    {
                        database.CreateCollection(VERSION_INFO_COLLECTION);
                    }

                    var tempVersion = GetTempVersion(database, out var collection);

                    foreach (var migrationInfo in sortedMigrationData)
                    {
                        var migration = migrationInfo.Migration;
                        migration.Up();
                        var versionInfo = new MongoVersionInfo
                        {
                            Date = DateTime.UtcNow,
                            Description = migrationInfo.Description,
                            ToVersion = migrationInfo.Version,
                            FromVersion = tempVersion
                        };

                        collection.InsertOneAsync(versionInfo);
                    }
                });
            }
            catch (Exception e)
            {
                var message = $"Ошибка во время накатывания " +
                              $"миграций из сборки {context.MigrationsAssembly}";
                throw new MongoException(message, e);
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
            }
        }

        public void MigrateDown(
            MongoDbContext context, 
            string downVersion)
        {
            AppDomain domain = null;

            try
            {
                if (string.IsNullOrWhiteSpace(context.MigrationsAssembly))
                {
                    throw new NullReferenceException("Не указана сборка с миграциями");
                }

                if (downVersion.Length != 14 ||
                    !long.TryParse(downVersion, out _))
                {
                    throw new InvalidOperationException("Указана невалидная версия");
                }

                domain = AppDomain.CreateDomain(MIGRATIONS_DOMAIN);
                var migrationsAssembly = domain.Load(context.MigrationsAssembly);

                context.ExecuteTransaction(database =>
                {
                    var migrationVersions = GetMigrationsInfo(database, migrationsAssembly);
                    var sortedMigrationVersions = migrationVersions
                        .OrderBy(x => long.Parse(x.Version))
                        .Where(x => long.Parse(x.Version) > long.Parse(downVersion));

                    var collectionExists = GetVersionCollectionExists(database);

                    if (!collectionExists)
                    {
                        database.CreateCollection(VERSION_INFO_COLLECTION);
                    }

                    var tempVersion = GetTempVersion(database, out var collection);

                    foreach (var migrationInfo in sortedMigrationVersions)
                    {
                        var migration = migrationInfo.Migration;
                        migration.Down();

                        var versionInfo = new MongoVersionInfo
                        {
                            Date = DateTime.UtcNow,
                            Description = migrationInfo.Description,
                            ToVersion = migrationInfo.Version,
                            FromVersion = tempVersion
                        };

                        collection.InsertOneAsync(versionInfo);
                    }
                });
            }
            catch (Exception e)
            {
                var message = $"Ошибка во время откатывания " +
                              $"миграций из сборки {context.MigrationsAssembly} " +
                              $"до версии {downVersion}";
                throw new MongoException(message, e);
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
            }
        }

        public void MigrateDown(
            MongoDbContext context,
            DateTime versionTime)
        {
            var day = versionTime.Day.ToString().PadLeft(2);
            var month = versionTime.Month.ToString().PadLeft(2);
            var year = versionTime.Year.ToString();
            var hour = versionTime.Hour.ToString().PadLeft(2);
            var minute = versionTime.Minute.ToString().PadLeft(2);
            var second = versionTime.Second.ToString().PadLeft(2);

            var version = string.Concat(year, month, day, hour, minute, second);

            MigrateDown(context, version);
        }

        private static IEnumerable<MongoMigrationInfo> GetMigrationsInfo(
            IMongoDatabase database, 
            Assembly migrationAssembly)
        {
            var migrationType = typeof(MongoMigration);
            var migrations = migrationAssembly.GetTypes().Where(x => x.IsSubclassOf(migrationType));

            var result = new List<MongoMigrationInfo>();

            foreach (var migration in migrations)
            {
                var attributes = migration.GetCustomAttributes(false);
                var versionAttribute = attributes.SingleOrDefault(x => x is MongoMigrationAttribute);

                if (versionAttribute == null)
                    throw new CustomAttributeFormatException($"Не задана версия миграции для { migration.Name }");

                var versionAttr = (MongoMigrationAttribute) versionAttribute;
                var typedMigration = (MongoMigration)Activator.CreateInstance(migration, database);

                var info = new MongoMigrationInfo
                {
                    MigrationAttribute = versionAttr,
                    Migration = typedMigration
                };

                result.Add(info);
            }

            return result;
        }

        private static string GetTempVersion(
            IMongoDatabase database, 
            out IMongoCollection<MongoVersionInfo> versionCollection)
        {
            var collection = database.GetCollection<MongoVersionInfo>(VERSION_INFO_COLLECTION);
            var versionsCursor = collection.FindSync(Builders<MongoVersionInfo>.Filter.Empty);
            var versions = versionsCursor.ToList();

            var lastVersionInfo = versions.OrderBy(x => x.Date).LastOrDefault();
            var tempVersion = lastVersionInfo?.ToVersion;

            versionCollection = collection;
            return tempVersion;
        }

        private static bool GetVersionCollectionExists(IMongoDatabase database)
        {
            var filter = new MongoCollectionFilter
            {
                Name = VERSION_INFO_COLLECTION
            }.ToBsonDocument();
            var options = new ListCollectionsOptions { Filter = filter };

            var collections = database.ListCollections(options);
            var collectionExists = collections.Any();

            return collectionExists;
        }
    }
}
