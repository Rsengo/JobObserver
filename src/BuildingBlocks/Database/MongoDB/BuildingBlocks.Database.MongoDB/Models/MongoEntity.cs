﻿using BuildingBlocks.Database.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.Database.MongoDB.Models
{
    public abstract class MongoEntity: BaseEntity<long>
    {
        [BsonId]
        public override long Id { get; set; }
    }
}
