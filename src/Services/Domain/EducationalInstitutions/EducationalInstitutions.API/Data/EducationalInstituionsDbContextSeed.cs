using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalInstitutions.API.Data
{
    public class EducationalInstituionsDbContextSeed
    {
        public async Task SeedAsync(
            EducationalInstitutionsDbContext context, 
            ILogger<EducationalInstituionsDbContextSeed> logger)
        {
            try
            {
                var institutionId = await AddUniversity(context);
                await AddUniversitySynonyms(institutionId, context);
                var fucultyId = await AddFaculty(context, institutionId);
                await AddFacultySynonyms(fucultyId, context);
            }
            catch (Exception ex)
            {
                logger.LogError("Educational Instituions seed error: {@ex}", ex);
                throw;
            }
        }

        private async Task<long> AddUniversity(EducationalInstitutionsDbContext context)
        {
            var institution = new EducationalInstitution
            {
                Name = "Томский Политехнический Университет",
                SiteUrl = "http://tpu.ru/",
                Acronym = "НИ ТПУ",
                Description = "Политех"
            };

            await context.EducationalInstitutions.AddAsync(institution);
            await context.SaveChangesAsync();

            return institution.Id;
        }

        private async Task AddUniversitySynonyms(long universityId, EducationalInstitutionsDbContext context)
        {
            var institutionSynonyms = new[]
            {
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "Национальный Исследовательский Томский Политехнический Университет"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "Национальный Исследовательский ТПУ"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "НИ Томский Политехнический Университет"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "ТПУ"},
            };

            await context.EducationalInstitutionSynonyms.AddRangeAsync(institutionSynonyms);
            await context.SaveChangesAsync();
        }

        private async Task<long> AddFaculty(EducationalInstitutionsDbContext context, long universityId)
        {
            var faculty = new Faculty()
            {
                EducationalInstitutionId = universityId,
                Name = "Инженерная Школа Информационных технологий и Робототехники",
                Acronym = "ИШИТР",
                Description = "Институт кибернетики (школа)"
            };

            await context.Faculties.AddAsync(faculty);
            await context.SaveChangesAsync();

            return faculty.Id;
        }

        private async Task AddFacultySynonyms(long facultyId, EducationalInstitutionsDbContext context)
        {
            var facultySynonyms = new[]
            {
                new FacultySynonyms { FacultyId = facultyId, Name = "ИК" },
                new FacultySynonyms { FacultyId = facultyId, Name = "Институт Кибернетики" },
            };

            await context.FacultySynonyms.AddRangeAsync(facultySynonyms);
            await context.SaveChangesAsync();
        }
    }
}
