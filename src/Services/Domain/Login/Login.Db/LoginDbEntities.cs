using System;
using System.Collections.Generic;
using System.Text;
using Login.Db.Models;
using Login.Db.Models.Attributes;
using Login.Db.Models.Contacts;
using Login.Db.Models.Genders;
using Login.Db.Models.Geographic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login.Db
{
    public partial class LoginDbContext : IdentityDbContext<User>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            builder.EnableAutoHistory(null);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Area> Areas { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }

        public virtual DbSet<Site> Sites { get; set; }

        public virtual DbSet<SiteType> SiteTypes { get; set; }

        public virtual DbSet<EducationalInstitutionManagerAttributes> EducationalInstitutionManagerAttributes { get; set; }

        public virtual DbSet<EmployerManagerAttributes> EmployerManagerAttributes { get; set; }
    }
}
