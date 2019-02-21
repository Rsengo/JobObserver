using System;
using BrandedTemplates.Db.Models;
using BuildingBlocks.MongoDB.Migration;
using MongoDB.Driver;

namespace BrandedTemplates.Db.Migrations
{
    [MongoMigration(21, 02, 2019, 17, 30, 00, "Инициализация коллекций")]
    public class InitialMigration: MongoMigration
    {
        public InitialMigration(IMongoDatabase database) : base(database)
        {
        }

        public override void Up()
        {
            Database.CreateCollection(nameof(BrandedTemplate));
        }

        public override void Down()
        {
            Database.DropCollection(nameof(BrandedTemplate));
        }
    }
}
