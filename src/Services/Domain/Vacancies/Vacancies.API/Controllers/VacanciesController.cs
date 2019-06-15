using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models;
using Vacancies.Db.Dto.Models;
using Vacancies.API.Filters;
using Vacancies.API.Filters.Builders;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class VacanciesController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public VacanciesController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.Vacancies
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
                .Include(x => x.VacancyStatus)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
            await _context.Industries.LoadAsync();

            var dto = Mapper.Map<DtoVacancy>(result);

            return Ok(dto);
        }

        [HttpGet("byEmployer/{id}")]
        public async Task<IActionResult> GetByCompany([FromRoute]long id)
        {
            var result = await _context.Vacancies
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
    .Include(x => x.VacancyStatus)
    .Where(x => x.EmployerId == id)
    .ToListAsync()
    .ConfigureAwait(false);

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
            await _context.Industries.LoadAsync();

            var dto = result.Select(Mapper.Map<DtoVacancy>).ToList();

            return Ok(dto);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination([FromBody]PaginationFilter filter)
        {
            var result = await _context.Vacancies
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
                .Include(x => x.VacancyStatus)
                .Skip(filter.Offset)
                .Take(filter.Count)
                .ToListAsync()
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
            await _context.Industries.LoadAsync();

            var dto = result.Select(Mapper.Map<DtoVacancy>).ToList();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoVacancy dto)
        {
            var entity = Mapper.Map<Vacancy>(dto);
            entity.PublishedAt = DateTime.UtcNow;

            _context.Vacancies.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoVacancy dto, [FromRoute]long id)
        {
            var template = Mapper.Map<Vacancy>(dto);

            template.Id = id;

            await _context.Vacancies
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _context.Vacancies
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] VacancySearchFilter filter)
        {
            var builder = new VacancySearchBuilder(_context);
            var query = builder.BuildQuery(filter);

            var includableQuery = query
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
                .Include(x => x.VacancyStatus)
                .Skip(filter.Offset)
                .Take(filter.Count);

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.Specializations.LoadAsync();
            await _context.Industries.LoadAsync();

            var result = await includableQuery.ToListAsync();
            var dto = result.Select(Mapper.Map<DtoVacancy>).ToList();

            return Ok(dto);
        }
    }
}
