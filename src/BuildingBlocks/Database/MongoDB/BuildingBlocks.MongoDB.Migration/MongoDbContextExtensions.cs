using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.MongoDB.Migration
{
    public static class MongoDbContextExtensions
    {
        public static void MigrateUp(this MongoDbContext context)
        {
            MongoMigrator.Instance.MigrateUp(context);
        }

        public static void MigrateDown(this MongoDbContext context, string version)
        {
            MongoMigrator.Instance.MigrateDown(context, version);
        }

        public static void MigrateDown(this MongoDbContext context, DateTime version)
        {
            MongoMigrator.Instance.MigrateDown(context, version);
        }
    }
}
