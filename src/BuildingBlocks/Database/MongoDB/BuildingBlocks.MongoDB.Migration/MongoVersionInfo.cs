using System;
using BuildingBlocks.MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.MongoDB.Migration
{

    public class MongoVersionInfo: MongoEntity
    {
        public string FromVersion { get; set; }

        public string ToVersion { get; set; }

        [BsonDateTimeOptions(Representation = BsonType.Document)]
        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
