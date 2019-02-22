using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.MongoDB.Models
{
    public abstract class MongoEntity
    {
        [BsonId]
        public long Id { get; set; }
    }
}
