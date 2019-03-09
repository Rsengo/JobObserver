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
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            builder.EnableAutoHistory(null);

            base.OnModelCreating(builder);
        }

        public DbSet<BrandedTemplate> BrandedTemplates { get; set; }
    }
}
