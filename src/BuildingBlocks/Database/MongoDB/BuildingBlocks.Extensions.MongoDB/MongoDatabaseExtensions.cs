using BuildingBlocks.Database.MongoDB.Models;
using MongoDB.Driver;

namespace BuildingBlocks.Extensions.MongoDB
{
    public static class MongoDatabaseExtensions
    {
        public static IMongoCollection<TEntity> GetCollection<TEntity>(this IMongoDatabase database) 
            where TEntity: MongoEntity
        {
            return database.GetCollection<TEntity>(nameof(TEntity));
        }
    }
}
