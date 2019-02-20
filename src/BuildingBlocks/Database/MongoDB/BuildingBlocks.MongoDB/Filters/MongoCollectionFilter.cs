using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.MongoDB.Filters
{
    public class MongoCollectionFilter
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
