﻿using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.Database.MongoDB.Filters
{
    public class MongoCollectionFilter
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
