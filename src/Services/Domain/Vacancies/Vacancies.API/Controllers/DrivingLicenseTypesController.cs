using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Driving;
using Vacancies.Db.Dto.Models.Driving;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/vacancies")]
    public class DrivingLicenseTypesController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public DrivingLicenseTypesController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.VacancyDrivingLicenseTypes
                .Include(x => x.DrivingLicenseType)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancyDrivingLicenseType>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/drivingLicenseTypes")]
        public async Task<IActionResult> GetByVacancy(long id)
        {
            var result = await _context.VacancyDrivingLicenseTypes
                .Where(x => x.VacancyId == id)
                .Include(x => x.DrivingLicenseType)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancyDrivingLicenseType>(result);

            return Ok(dto);
        }

        [HttpPost("drivingLicenseTypes")]
        public async Task<IActionResult> Post(DtoVacancyDrivingLicenseType dto)
        {
            var entity = Mapper.Map<VacancyDrivingLicenseType>(dto);
            _context.VacancyDrivingLicenseTypes.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Update(DtoVacancyDrivingLicenseType dto, long id)
        {
            var template = Mapper.Map<VacancyDrivingLicenseType>(dto);

            template.Id = id;

            await _context.VacancyDrivingLicenseTypes
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.VacancyDrivingLicenseTypes
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
