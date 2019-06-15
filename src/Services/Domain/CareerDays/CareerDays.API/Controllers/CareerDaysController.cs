using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Db.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.API.Controllers
{
    using System;

    using CareerDays.API.Filters;

    [Route("api/v1/[controller]")]
    public class CareerDaysController : ControllerBase
    {
        private readonly CareerDaysDbContext _context;

        public CareerDaysController(CareerDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.CareerDays
                .Include(x => x.Address)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Employers)
                    .ThenInclude(x => x.Employer)
                .Include(x => x.EducationalInstitutions)
                    .ThenInclude(x => x.EducationalInstitution)
                .Include(x => x.BrandedDescription)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result); ;
                

            return Ok(dto);
        }

        [HttpGet("byEmployer/{employerId}")]
        public async Task<IActionResult> GetByEmployer([FromRoute]long employerId)
        {
            var result = await _context.CareerDays
                .Include(x => x.Address)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Employers)
                    .ThenInclude(x => x.Employer)
                .Include(x => x.EducationalInstitutions)
                    .ThenInclude(x => x.EducationalInstitution)
                .Include(x => x.BrandedDescription)
                .SingleOrDefaultAsync(x => x.EmployerId == employerId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byEducationalInstitution/{educationalInstitutionId}")]
        public async Task<IActionResult> GetByEducationalInstitution([FromRoute]long educationalInstitutionId)
        {
            var result = await _context.CareerDays
                .Include(x => x.Address)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Employers)
                    .ThenInclude(x => x.Employer)
                .Include(x => x.EducationalInstitutions)
                    .ThenInclude(x => x.EducationalInstitution)
                .Include(x => x.BrandedDescription)
                .SingleOrDefaultAsync(x => x.EducationalInstitutionId == educationalInstitutionId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byArea/{areaId}")]
        public async Task<IActionResult> GetByArea([FromRoute]long areaId)
        {
            var result = await _context.CareerDays
                .Include(x => x.Address)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Employers)
                    .ThenInclude(x => x.Employer)
                .Include(x => x.EducationalInstitutions)
                    .ThenInclude(x => x.EducationalInstitution)
                .Include(x => x.BrandedDescription)
                .SingleOrDefaultAsync(x => x.Address.AreaId == areaId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filtered = await _context.CareerDays
                .Include(x => x.Address)
                    .ThenInclude(x => x.Station)
                        .ThenInclude(x => x.Line)
                            .ThenInclude(x => x.Metro)
                .Include(x => x.Employers)
                    .ThenInclude(x => x.Employer)
                .Include(x => x.EducationalInstitutions)
                    .ThenInclude(x => x.EducationalInstitution)
                .Include(x => x.BrandedDescription)
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoCareerDay>).ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]DtoCareerDay dto)
        {
            var template = Mapper.Map<CareerDay>(dto);

            _context.CareerDays.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoCareerDay dto, [FromRoute]long id)
        {
            var template = Mapper.Map<CareerDay>(dto);

            template.Id = id;

            await _context.CareerDays
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _context.CareerDays
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("educationalInstitution")]
        public async Task<IActionResult> AddEducationalInstitution([FromBody]DtoCareerDayEducationalInstitution dto)
        {
            var model = Mapper.Map<CareerDayEducationalInstitution>(dto);
            _context.CareerDayEducationalInstitutions.Add(model);
            await _context.SaveChangesAsync();

            var result = Mapper.Map<DtoCareerDayEducationalInstitution>(model);

            return Ok(result);
        }

        [HttpPut("educationalInstitution/{id}")]
        public async Task<IActionResult> EditEducationalInstitution(
            [FromBody]DtoCareerDayEducationalInstitution dto, 
            [FromRoute]long id)
        {
            var model = Mapper.Map<CareerDayEducationalInstitution>(dto);
            model.Id = id;

            await _context.CareerDayEducationalInstitutions
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => model);

            var result = Mapper.Map<DtoCareerDayEducationalInstitution>(model);

            return Ok(result);
        }

        [HttpDelete("educationalInstitution/{id}")]
        public async Task<IActionResult> RemoveEducationalInstitution([FromRoute]long id)
        {
            await _context.CareerDayEducationalInstitutions
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync();

            return Ok();
        }

        [HttpPost("employer")]
        public async Task<IActionResult> AddEmployer([FromBody]DtoCareerDayEmployer dto)
        {
            var model = Mapper.Map<CareerDayEmployer>(dto);
            _context.CareerDayEmployers.Add(model);
            await _context.SaveChangesAsync();

            var result = Mapper.Map<DtoCareerDayEmployer>(model);

            return Ok(result);
        }

        [HttpPut("employer/{id}")]
        public async Task<IActionResult> EditEmployer([FromBody]DtoCareerDayEmployer dto, [FromRoute]long id)
        {
            var model = Mapper.Map<CareerDayEmployer>(dto);
            model.Id = id;

            await _context.CareerDayEmployers
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => model);

            var result = Mapper.Map<DtoCareerDayEmployer>(model);

            return Ok(result);
        }

        [HttpDelete("employer/{id}")]
        public async Task<IActionResult> RemoveEmployer([FromRoute]long id)
        {
            await _context.CareerDayEmployers
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync();

            return Ok();
        }
    }
}
