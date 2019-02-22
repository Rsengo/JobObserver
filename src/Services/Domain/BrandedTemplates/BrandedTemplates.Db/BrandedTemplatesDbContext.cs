using BrandedTemplates.Db.Maps;
using BrandedTemplates.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandedTemplates.Db
{
    public class BrandedTemplatesDbContext: DbContext
    {
        public BrandedTemplatesDbContext(DbContextOptions<BrandedTemplatesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrandedTemplateMap());
            base.OnModelCreating(builder);
        }

        public DbSet<BrandedTemplate> BrandedTemplates { get; set; }
    }
}
