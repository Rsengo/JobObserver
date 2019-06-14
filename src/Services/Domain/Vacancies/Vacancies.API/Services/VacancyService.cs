using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacancies.API.Filters;
using Vacancies.API.Filters.Builders;
using Vacancies.Db;
using Vacancies.Db.Models;

namespace Vacancies.API.Services
{
    public class VacancyService
    {
        private readonly VacanciesDbContext _context;

        public VacancyService(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task<Vacancy> GetAsync(long id)
        {
            var request = CreateRequest();
            var result = await request
                .SingleOrDefaultAsync(x => x.Id == id);

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Vacancy>> GetAsync()
        {
            var request = CreateRequest();
            var result = await request
                .ToListAsync();

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Vacancy>> GetAsync(PaginationFilter filter)
        {
            var request = CreateRequest();
            var result = await request
                .Skip(filter.Offset)
                .Take(filter.Count)
                .ToListAsync();

            await LoadReferences();

            return result;
        }

        public async Task<IEnumerable<Vacancy>> GetAsync(VacancySearchFilter filter)
        {
            var builder = new VacancySearchBuilder(_context);
            var query = builder.BuildQuery(filter);

            var request = IncludeReferences(query);

            var result = await request.ToListAsync();

            await LoadReferences();

            return result;
        }

        public IQueryable<Vacancy> CreateRequest()
        {
            var query = _context.Vacancies;
            var includableQuery = IncludeReferences(query);

            return includableQuery;
        }

        public static IQueryable<Vacancy> IncludeReferences(IQueryable<Vacancy> query)
        {
            return query
            .Include(x => x.Address)
                    //.AlsoInclude(x => x.Area)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Department)
                .Include(x => x.DrivingLicenseTypes)
                    .ThenInclude(x => x.DrivingLicenseType)
                .Include(x => x.Employer)
                .Include(x => x.Employment)
                //.Include(x => x.Industry)
                .Include(x => x.KeySkills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.Languages)
                //.AlsoInclude(x => x.Language)
                //.AlsoInclude(x => x.Level)
                .Include(x => x.Specializations)
                //.ThenInclude(x => x.Specialization)
                .Include(x => x.Salary)
                    .ThenInclude(x => x.Currency)
                .Include(x => x.Schedule)
                .Include(x => x.Tests)
                .Include(x => x.VacancyStatus);
        }

        public async Task LoadReferences()
        {
            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
            await _context.Industries.LoadAsync();
        }
    }
}
