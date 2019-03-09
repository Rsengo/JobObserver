using Dictionaries.Db.Models.Driving;
using Dictionaries.Db.Models.Educations;
using Dictionaries.Db.Models.Employer;
using Dictionaries.Db.Models.Employments;
using Dictionaries.Db.Models.Geographic;
using Dictionaries.Db.Models.Geographic.Metro;
using Dictionaries.Db.Models.Industries;
using Dictionaries.Db.Models.Languages;
using Dictionaries.Db.Models.Negotiations;
using Dictionaries.Db.Models.Salaries;
using Dictionaries.Db.Models.Schedules;
using Dictionaries.Db.Models.Skills;
using Dictionaries.Db.Models.Specializations;
using Dictionaries.Db.Models.Statuses;
using Dictionaries.Db.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.Db
{
    public partial class DictionariesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            base.OnModelCreating(builder);
        }

        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }

        public DbSet<EducationalLevel> EducationalLevels { get; set; }

        public DbSet<EmployerType> EmployerTypes { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Metro> Metro { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<LanguageLevel> LanguageLevels { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<ResumeStatus> ResumeStatuses { get; set; }

        public DbSet<VacancyStatus> VacancyStatuses { get; set; }

        public DbSet<Gender> Genders { get; set; }
    }
}
