using MongoDB.Driver;

namespace BuildingBlocks.Migrations.MongoDB
{
    public abstract class MongoMigration
    {
        protected IMongoDatabase Database { get; }

        public MongoMigration(IMongoDatabase database)
        {
            Database = database;
        }

        public abstract void Up();

        public abstract void Down();
    }
}
