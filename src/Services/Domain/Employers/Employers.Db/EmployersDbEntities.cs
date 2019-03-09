using System;
using System.Collections.Generic;
using System.Text;
using Employers.Db.Models;
using Employers.Db.Models.Geographic;
using Employers.Db.Models.Synonyms;
using Microsoft.EntityFrameworkCore;

namespace Employers.Db
{
    public partial class EmployersDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            base.OnModelCreating(builder);
        }

        public DbSet<Area> Areas { get; set; }

        public DbSet<EmployerSynonyms> EmployerSynonyms { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<EmployerType> EmployerTypes { get; set; }

        public DbSet<Partners> Partners { get; set; }
    }
}
