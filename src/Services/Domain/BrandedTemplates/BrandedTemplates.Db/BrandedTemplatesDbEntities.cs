using System;
using System.Collections.Generic;
using System.Text;
using BrandedTemplates.Db.Maps;
using BrandedTemplates.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandedTemplates.Db
{
    public partial class BrandedTemplatesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrandedTemplateMap());
            base.OnModelCreating(builder);
        }

        public DbSet<BrandedTemplate> BrandedTemplates { get; set; }
    }
}
