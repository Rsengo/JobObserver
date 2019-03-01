using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Employers;
using EducationalInstitutions.Db.Models.Geographic;
using EducationalInstitutions.Db.Models.Synonyms;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.Db
{
    public partial class EducationalInstitutionsDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<EducationalInstitutionSynonyms> EducationalInstitutionSynonyms { get; set; }

        public DbSet<FacultySynonyms> FacultySynonyms { get; set; }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Partners> Partners { get; set; }
    }
}
