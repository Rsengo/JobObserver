using BuildingBlocks.Database.Entity;

namespace BuildingBlocks.Database.MongoDB.Models
{
    using global::MongoDB.Bson.Serialization.Attributes;

    public abstract class MongoEntity: BaseEntity<long>
    {
        [BsonId]
        public override long Id { get; set; }
    }
}
