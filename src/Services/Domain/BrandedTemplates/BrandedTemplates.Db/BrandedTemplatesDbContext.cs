using System;
using System.Collections.Generic;
using System.Text;

namespace BrandedTemplates.Db
{
    using BuildingBlocks.MongoDB;

    using MongoDB.Driver;

    public class BrandedTemplatesDbContext: MongoDbContext
    {
        public BrandedTemplatesDbContext(IMongoDatabase database) 
            : base(database)
        {
        }
    }
}
