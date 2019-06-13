using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Resumes.API.Filters;
using Resumes.API.Filters.Builders;
using Resumes.Db;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Services
{
    public class ResumeService
    {
        private readonly ResumesDbContext _context;

        public ResumeService(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task<Resume> GetAsync(long id)
        {
            var request = CreateRequest();
            var result = await request
                .SingleOrDefaultAsync(x => x.Id == id);

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Resume>> GetAsync()
        {
            var request = CreateRequest();
            var result = await request
                .ToListAsync();

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Resume>> GetAsync(PaginationFilter filter)
        {
            var request = CreateRequest();
            var result = await request
                .Skip(filter.Offset)
                .Take(filter.Count)
                .ToListAsync();

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Resume>> GetAsync(ResumeSearchFilter filter)
        {
            var builder = new ResumeSearchBuilder(_context);
            var query = builder.BuildQuery(filter);

            var request = IncludeReferences(query);

            var result = await request.ToListAsync();

            await LoadReferences();

            return result;
        }

        public IQueryable<Resume> CreateRequest()
        {
            var query = _context.Resumes;
            var includableQuery = IncludeReferences(query);

            return includableQuery;
        }

        public static IQueryable<Resume> IncludeReferences(IQueryable<Resume> query)
        {
            return query
            //.Include(x => x.Area)
            .Include(x => x.Applicant)
                .ThenInclude(x => x.Gender)
            .Include(x => x.BusinessTripReadiness)
            .Include(x => x.Certificates)
            .Include(x => x.Citizenship)
                .ThenInclude(x => x.Area)
            .Include(x => x.DrivingLicenseTypes)
                .ThenInclude(x => x.DrivingLicenseType)
            .Include(x => x.Education)
                //.AlsoInclude(x => x.EducationalLevel)
                .ThenInclude(x => x.Specializations)
                    .ThenInclude(x => x.Specialization)
            .Include(x => x.Employments)
                .ThenInclude(x => x.Employment)
            .Include(x => x.Experience)
                .ThenInclude(x => x.Specialization)
            .Include(x => x.Languages)
            //.AlsoInclude(x => x.Level)
            //.AlsoInclude(x => x.Language)
            .Include(x => x.MetroStation)
                .ThenInclude(x => x.Line)
                    .ThenInclude(x => x.Metro)
            .Include(x => x.RelocationPossibility)
                .ThenInclude(x => x.RelocationType)
            .Include(x => x.ResumeLocale)
            .Include(x => x.Specializations)
            //.ThenInclude(x => x.Specialization)
            .Include(x => x.Salary)
                .ThenInclude(x => x.Currency)
            .Include(x => x.Schedules)
                .ThenInclude(x => x.Schedule)
            .Include(x => x.Skills)
                .ThenInclude(x => x.Skill)
            .Include(x => x.TravelTime)
            .Include(x => x.WorkTicket)
                .ThenInclude(x => x.Area)
            .Include(x => x.ResumeStatus);
        }

        public async Task LoadReferences()
        {
            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.EducationalLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
        }
    }
}
