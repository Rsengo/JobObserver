using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BuildingBlocks.MongoDB.Migration;
using MongoDB.Driver;

namespace BuildingBlocks.MongoDB
{
    public abstract class MongoDbContext
    {
        public string MigrationsAssembly { get; set; }

        public IMongoDatabase Database { get; set; }

        public IMongoClient Client => Database.Client;

        public virtual void Migrate()
        {
            using (Client.StartSession())
            {
                
            }
        }
    }
}
