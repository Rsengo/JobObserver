using BuildingBlocks.Database.Entity;
using MongoDB.Bson;

namespace BuildingBlocks.Database.MongoDB.Models
{
    public abstract class MongoEntity: BaseEntity<ObjectId>
    {
    }
}
