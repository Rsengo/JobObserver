using Employers.Db;
using Employers.Db.Models;
using Employers.Db.Models.Synonyms;
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

        public EmployersDbContextSeed(
            EmployersDbContext context,
            ILogger<EmployersDbContextSeed> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            try
            {
                var id = await AddEmployer(_context);
                await AddEmployerSynonyms(_context, id);
                await AddDepartments(_context, id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Employers seed error: {@ex}", ex);
                throw;
            }
        }

        private static async Task<long> AddEmployer(EmployersDbContext context)
        {
            var employer = new Employer
            {
                Acronym = "КМПН",
                Description = "Описание",
                Name = "Компания",
                SiteUrl = "http://company.com/"
            };

            await context.Employers.AddAsync(employer);
            await context.SaveChangesAsync();

            return employer.Id;
        }

        private static async Task AddEmployerSynonyms(EmployersDbContext context, long employerId)
        {
            var synonyms = new[]
            {
                new EmployerSynonyms { EmployerId = employerId, Name = "Company" }
            };

            await context.EmployerSynonyms.AddRangeAsync(synonyms);
            await context.SaveChangesAsync();
        }

        private static async Task AddDepartments(EmployersDbContext context, long employerId)
        {
            var department = new Department
            {
                OrganizationId = employerId,
                Name = "Отдел",
                Description = "Отдел компании"
            };

            await context.Departments.AddAsync(department);
            await context.SaveChangesAsync();
        }
    }
}
