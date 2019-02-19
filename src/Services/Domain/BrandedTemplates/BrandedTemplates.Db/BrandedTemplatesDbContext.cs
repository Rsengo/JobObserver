using BuildingBlocks.MongoDB;
using MongoDB.Driver;
using BrandedTemplates.Db.Models;
using BuildingBlocks.Extensions.MongoDB;

namespace BrandedTemplates.Db
{
    public class BrandedTemplatesDbContext: MongoDbContext
    {
        public BrandedTemplatesDbContext(IMongoDatabase database) 
            : base(database)
        {
        }
    }
}
