using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Specializations;
using Vacancies.Dto.Models.Specializations;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/vacancies")]
    public class SpecializationsController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public SpecializationsController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("specializations/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.VacancySpecializations
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancySpecialization>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/specializations")]
        public async Task<IActionResult> GetByVacancy(long id)
        {
            var result = await _context.VacancySpecializations
                .Where(x => x.VacancyId == id)
                .Include(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancySpecialization>(result);

            return Ok(dto);
        }

        [HttpPost("specializations")]
        public async Task<IActionResult> Post(DtoVacancySpecialization dto)
        {
            var entity = Mapper.Map<VacancySpecialization>(dto);
            _context.VacancySpecializations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("specializations/{id}")]
        public async Task<IActionResult> Update(DtoVacancySpecialization dto, long id)
        {
            var template = Mapper.Map<VacancySpecialization>(dto);

            template.Id = id;

            await _context.VacancySpecializations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("specializations/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.VacancySpecializations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}