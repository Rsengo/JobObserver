using BuildingBlocks.Database.MongoDB.Models;
using MongoDB.Bson.Serialization;

namespace BuildingBlocks.Database.MongoDB.Mapping
{
    public abstract class MongoClassMap<TEntity> 
        where TEntity : MongoEntity
    {
        private void Build()
        {
            BsonClassMap.RegisterClassMap<TEntity>(ConfigureModel);
        }

        public abstract void ConfigureModel(BsonClassMap<TEntity> builder);
    }
}
