using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Dto.Models;
using Employers.Db.Models;
using Employers.Db.Models.Synonyms;
using Employers.Db.Synchronization.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employers.API.Data
{
    public class EmployersDbContextSeed
    {
        private readonly EmployersDbContext _context;

        private readonly ILogger<EmployersDbContextSeed> _logger;

        private readonly IEventBus _eventBus;

        public EmployersDbContextSeed(
            EmployersDbContext context,
            ILogger<EmployersDbContextSeed> logger,
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
                var id = await AddEmployer();
                await AddEmployerSynonyms(id);
                await AddDepartments(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Employers seed error: {@ex}", ex);
                throw;
            }
        }

        private async Task<long> AddEmployer()
        {
            var employer = new Employer
            {
                Acronym = "КМПН",
                Description = "Описание",
                Name = "Компания",
                SiteUrl = "http://company.com/"
            };

            _context.Employers.Add(employer);
            await _context.SaveChangesAsync();

            var @event = new EmployersChanged
            {
                Created = new[] { Mapper.Map<DtoEmployer>(employer) }
            };

            _eventBus.Publish(@event);

            return employer.Id;
        }

        private async Task AddEmployerSynonyms(long employerId)
        {
            var synonyms = new[]
            {
                new EmployerSynonyms { EmployerId = employerId, Name = "Company" }
            };

            _context.EmployerSynonyms.AddRange(synonyms);
            await _context.SaveChangesAsync();
        }

        private async Task AddDepartments(long employerId)
        {
            var department = new Department
            {
                OrganizationId = employerId,
                Name = "Отдел",
                Description = "Отдел компании"
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            var @event = new DepartmentsChanged
            {
                Created = new[] { Mapper.Map<DtoDepartment>(department) }
            };

            _eventBus.Publish(@event);
        }
    }
}
