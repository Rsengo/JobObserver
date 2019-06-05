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
        public async Task SeedAsync(
            EmployersDbContext context, 
            ILogger<EmployersDbContextSeed> logger)
        {
            try
            {
                var id = await AddEmployer(context);
                await AddEmployerSynonyms(context, id);
                await AddDepartments(context, id);
            }
            catch (Exception ex)
            {
                logger.LogError("Employers seed error: {@ex}", ex);
                throw;
            }
        }

        private async Task<long> AddEmployer(EmployersDbContext context)
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

        private async Task AddEmployerSynonyms(EmployersDbContext context, long employerId)
        {
            var synonyms = new[]
            {
                new EmployerSynonyms { EmployerId = employerId, Name = "Company" }
            };

            await context.EmployerSynonyms.AddRangeAsync(synonyms);
            await context.SaveChangesAsync();
        }

        private async Task AddDepartments(EmployersDbContext context, long employerId)
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
