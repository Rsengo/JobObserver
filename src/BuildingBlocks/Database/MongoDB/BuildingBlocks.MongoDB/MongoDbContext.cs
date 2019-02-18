using System;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BuildingBlocks.MongoDB
{
    public abstract class MongoDbContext: IDisposable
    {
        private readonly IClientSession _session;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoClientSettings ClientSettings => _client.Settings;

        public MongoDatabaseSettings DatabaseSettings => _database.Settings;

        public string MigrationsAssembly { get; set; }


        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
            _client = database.Client;
            _session = _client.StartSession();
        }

        public async Task ExecuteTransactionAsync(Func<IMongoDatabase, Task> action)
        {
            try
            {
                _session.StartTransaction();
                await action(_database)
                    .ConfigureAwait(false);
                await _session.CommitTransactionAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await _session.AbortTransactionAsync()
                    .ConfigureAwait(false);
                throw new MongoException(
                    "Ошибка во время выполнения асинхронной транзакции", ex);
            }
        }

        public void ExecuteTransaction(Action<IMongoDatabase> action)
        {
            try
            {
                _session.StartTransaction();
                action(_database);
                _session.CommitTransaction();
            }
            catch (Exception ex)
            {
                _session.AbortTransaction();
                throw new MongoException(
                    "Ошибка во время выполнения синхронной транзакции", ex);
            }
        }

        public void Dispose()
        {
            _session?.Dispose();
        }
    }
}
