using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Migrations.MongoDB
{
    public abstract class MongoMigration
    {
        public abstract void Up();

        public abstract void Down();
    }
}
