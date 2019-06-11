using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Dto.Models;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Db.Synchronization.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalInstitutions.API.Data
{
    public class EducationalInstituionsDbContextSeed
    {
        private readonly EducationalInstitutionsDbContext _context;

        private readonly ILogger<EducationalInstituionsDbContextSeed> _logger;

        private readonly IEventBus _eventBus;

        public EducationalInstituionsDbContextSeed(
            EducationalInstitutionsDbContext context,
            ILogger<EducationalInstituionsDbContextSeed> logger,
            IEventBus eventBus)
        {
            _context = context;
            _logger = logger;
            _eventBus = eventBus;
        }

        public async Task SeedAsync()
        {
            try
            {
                var institutionId = await AddUniversity();
                await AddUniversitySynonyms(institutionId);
                var fucultyId = await AddFaculty(institutionId);
                await AddFacultySynonyms(fucultyId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Educational Instituions seed error: {@ex}", ex);
                throw;
            }
        }

        private async Task<long> AddUniversity()
        {
            var institution = new EducationalInstitution
            {
                Name = "Томский Политехнический Университет",
                SiteUrl = "http://tpu.ru/",
                Acronym = "НИ ТПУ",
                Description = "Политех",
                AreaId = await _context.Areas.Select(x => x.Id).FirstAsync()
            };

            _context.EducationalInstitutions.Add(institution);
            await _context.SaveChangesAsync();

            var @event = new EducationalInstitutionsChanged
            {
                Created = new[] { Mapper.Map<DtoEducationalInstitution>(institution) }
            };

            _eventBus.Publish(@event);

            return institution.Id;
        }

        private async Task AddUniversitySynonyms(long universityId)
        {
            var institutionSynonyms = new[]
            {
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "Национальный Исследовательский Томский Политехнический Университет"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "Национальный Исследовательский ТПУ"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "НИ Томский Политехнический Университет"},
                new EducationalInstitutionSynonyms() { EducationalInstitutionId = universityId, Name = "ТПУ"},
            };

            await _context.EducationalInstitutionSynonyms.AddRangeAsync(institutionSynonyms);
            await _context.SaveChangesAsync();
        }

        private async Task<long> AddFaculty(long universityId)
        {
            var faculty = new Faculty()
            {
                EducationalInstitutionId = universityId,
                Name = "Инженерная Школа Информационных технологий и Робототехники",
                Acronym = "ИШИТР",
                Description = "Институт кибернетики (школа)"
            };

            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();

            return faculty.Id;
        }

        private async Task AddFacultySynonyms(long facultyId)
        {
            var facultySynonyms = new[]
            {
                new FacultySynonyms { FacultyId = facultyId, Name = "ИК" },
                new FacultySynonyms { FacultyId = facultyId, Name = "Институт Кибернетики" },
            };

            _context.FacultySynonyms.AddRange(facultySynonyms);
            await _context.SaveChangesAsync();
        }
    }
}
