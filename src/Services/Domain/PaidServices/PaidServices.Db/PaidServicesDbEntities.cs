using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db.Models;

namespace PaidServices.Db
{
    public partial class PaidServicesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicantPaidService> ApplicantPaidServices { get; set; }

        public DbSet<EducationalInstitutionPaidService> EducationalInstitutionPaidServices { get; set; }

        public DbSet<EmployerPaidService> EmployerPaidServices { get; set; }
    }
}
