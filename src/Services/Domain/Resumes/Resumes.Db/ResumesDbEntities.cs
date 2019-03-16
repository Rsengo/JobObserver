using Microsoft.EntityFrameworkCore;
using Resumes.Db.Models;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Experiences;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Geographic.Metro;
using Resumes.Db.Models.Industries;
using Resumes.Db.Models.Languages;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Models.Skills;
using Resumes.Db.Models.Specializations;
using Resumes.Db.Models.Statuses;
using Resumes.Db.Models.Travel;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.Db
{
    public partial class ResumesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var tempAssembly = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(tempAssembly);

            builder.EnableAutoHistory(null);

            base.OnModelCreating(builder);
        }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<EducationalLevel> EducationalLevels { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Experience> Experiences { get; set; }

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

        public DbSet<ResumeNegotiation> ResumeNegotiations { get; set; }

        public DbSet<Citizenship> Citizenship { get; set; }

        public DbSet<WorkTicket> WorkTickets { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<ResumeStatus> ResumeStatuses { get; set; }

        public DbSet<RelocationPossibility> RelocationPossibilities { get; set; }

        public DbSet<RelocationType> RelocationTypes { get; set; }

        public DbSet<BusinessTripReadiness> BusinessTripReadiness { get; set; }

        public DbSet<TravelTime> TravelTimes { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<EducationSpecialization> EducationSpecializations { get; set; }

        public DbSet<ResumeDrivingLicenseType> ResumeDrivingLicenseTypes { get; set; }

        public DbSet<ResumeEmployment> ResumeEmployments { get; set; }

        public DbSet<ResumeSchedule> ResumeSchedules { get; set; }

        public DbSet<ResumeSkill> ResumeSkills { get; set; }

        public DbSet<ResumeSpecialization> ResumeSpecializations { get; set; }

        public DbSet<Gender> Genders { get; set; }
    }
}
