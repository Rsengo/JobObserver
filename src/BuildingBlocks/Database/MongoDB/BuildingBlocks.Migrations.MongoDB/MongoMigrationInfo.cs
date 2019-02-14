using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Migrations.MongoDB
{
    internal struct MongoMigrationInfo
    {
        public MongoMigration Migration { get; set; }

        public MongoMigrationAttribute MigrationAttribute { get; set; }

        public string Version => MigrationAttribute?.Version;

        public string Description => MigrationAttribute?.Description;
    }
}
