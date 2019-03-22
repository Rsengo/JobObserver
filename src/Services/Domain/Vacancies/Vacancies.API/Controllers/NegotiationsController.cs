using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Negotiations;
using Vacancies.Dto.Models.Negotiations;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class NegotiationsController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public NegotiationsController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.VacancyNegotiations
                .Include(x => x.Response)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancyNegotiation>(result);

            return Ok(dto);
        }

        [HttpGet("byVacancy/{id}")]
        public async Task<IActionResult> GetByVacancy(long id)
        {
            var result = await _context.VacancyNegotiations
                .Where(x => x.VacancyId == id)
                .Include(x => x.Response)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancyNegotiation>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoVacancyNegotiation dto)
        {
            var entity = Mapper.Map<VacancyNegotiation>(dto);
            _context.VacancyNegotiations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoVacancyNegotiation dto, long id)
        {
            var template = Mapper.Map<VacancyNegotiation>(dto);

            template.Id = id;

            await _context.VacancyNegotiations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.VacancyNegotiations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
