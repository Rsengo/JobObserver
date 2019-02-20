using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    using BuildingBlocks.MongoDB.Models;

    public static class MongoDatabaseExtensions
    {
        public static IMongoCollection<TEntity> GetCollection<TEntity>(this IMongoDatabase database) 
            where TEntity: MongoEntity
        {
            return database.GetCollection<TEntity>(nameof(TEntity));
        }
    }
}
