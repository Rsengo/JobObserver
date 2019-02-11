using BuildingBlocks.Database.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBlocks.Migrations.MongoDB
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
