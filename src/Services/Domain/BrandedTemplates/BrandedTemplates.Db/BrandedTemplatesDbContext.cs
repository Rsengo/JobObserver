using BrandedTemplates.Db.Maps;
using BrandedTemplates.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandedTemplates.Db
{
    public partial class BrandedTemplatesDbContext: DbContext
    {
        public BrandedTemplatesDbContext(DbContextOptions<BrandedTemplatesDbContext> options) : 
            base(options)
        {
        }
    }
}
