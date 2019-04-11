using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CareerDaysController : ControllerBase
    {
        private readonly CareerDaysDbContext _context;

        public CareerDaysController(CareerDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
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
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result); ;
                

            return Ok(dto);
        }

        [HttpGet("byEmployer/{employerId}")]
        public async Task<IActionResult> GetByEmployer(long employerId)
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
                .SingleOrDefaultAsync(x => x.EmployerId == employerId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byEducationalInstitution/{educationalInstitutionId}")]
        public async Task<IActionResult> GetByEducationalInstitution(long educationalInstitutionId)
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
                .SingleOrDefaultAsync(x => x.EducationalInstitutionId == educationalInstitutionId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byArea/{areaId}")]
        public async Task<IActionResult> GetByArea(long areaId)
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
                .SingleOrDefaultAsync(x => x.Address.AreaId == areaId)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoCareerDay dto)
        {
            var template = Mapper.Map<CareerDay>(dto);

            _context.CareerDays.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoCareerDay dto, long id)
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
        public async Task<IActionResult> Delete(long id)
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
        public async Task<IActionResult> AddEducationalInstitution(DtoCareerDayEducationalInstitution dto)
        {
            var model = Mapper.Map<CareerDayEducationalInstitution>(dto);
            _context.CareerDayEducationalInstitutions.Add(model);
            await _context.SaveChangesAsync();

            var result = Mapper.Map<DtoCareerDayEducationalInstitution>(model);

            return Ok(result);
        }

        [HttpPut("educationalInstitution/{id}")]
        public async Task<IActionResult> EditEducationalInstitution(DtoCareerDayEducationalInstitution dto, long id)
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
        public async Task<IActionResult> RemoveEducationalInstitution(long id)
        {
            await _context.CareerDayEducationalInstitutions
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync();

            return Ok();
        }

        [HttpPost("employer")]
        public async Task<IActionResult> AddEmployer(DtoCareerDayEmployer dto)
        {
            var model = Mapper.Map<CareerDayEmployer>(dto);
            _context.CareerDayEmployers.Add(model);
            await _context.SaveChangesAsync();

            var result = Mapper.Map<DtoCareerDayEmployer>(model);

            return Ok(result);
        }

        [HttpPut("employer/{id}")]
        public async Task<IActionResult> EditEmployer(DtoCareerDayEmployer dto, long id)
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
        public async Task<IActionResult> RemoveEmployer(long id)
        {
            await _context.CareerDayEmployers
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync();

            return Ok();
        }
    }
}
