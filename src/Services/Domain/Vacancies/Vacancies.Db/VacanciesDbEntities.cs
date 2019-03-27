using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db.Models;
using Vacancies.Db.Models.Driving;
using Vacancies.Db.Models.Employers;
using Vacancies.Db.Models.Employments;
using Vacancies.Db.Models.Geographic;
using Vacancies.Db.Models.Geographic.Metro;
using Vacancies.Db.Models.Industries;
using Vacancies.Db.Models.Languages;
using Vacancies.Db.Models.Negotiations;
using Vacancies.Db.Models.Salaries;
using Vacancies.Db.Models.Schedules;
using Vacancies.Db.Models.Skills;
using Vacancies.Db.Models.Specializations;
using Vacancies.Db.Models.Statuses;
using Vacancies.Db.Models.Tests;

namespace Vacancies.Db
{
    public partial class VacanciesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            builder.EnableAutoHistory(null);

            base.OnModelCreating(builder);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Metro> Metro { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageLevel> LanguageLevels { get; set; }

        public DbSet<LanguageSkill> LanguageSkills { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<VacancyNegotiation> VacancyNegotiations { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<VacancyStatus> VacancyStatuses { get; set; }

        public DbSet<VacancyTest> VacancyTests { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<VacancyDrivingLicenseType> VacancyDrivingLicenseTypes { get; set; }

        public DbSet<VacancySkill> VacancySkills { get; set; }

        public DbSet<VacancySpecialization> VacancySpecializations { get; set; }

        public DbSet<Specialization> Specializations { get; set; }
    }
}
