using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Tests;
using Vacancies.Db.Dto.Models.Tests;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public TestsController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.VacancyTests
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancyTest>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]DtoVacancyTest dto)
        {
            var template = Mapper.Map<VacancyTest>(dto);

            _context.VacancyTests.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoVacancyTest dto, [FromQuery]long id)
        {
            var template = Mapper.Map<VacancyTest>(dto);

            template.Id = id;

            await _context.VacancyTests
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]long id)
        {
            await _context.VacancyTests
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
