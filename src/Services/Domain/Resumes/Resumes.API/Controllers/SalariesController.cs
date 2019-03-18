using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Salaries;
using Resumes.Dto.Models.Salaries;

namespace Resumes.API.Controllers
{
    [Route("api/[controller]")]
    public class SalariesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public SalariesController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Salaries
                .Include(x => x.Currency)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoSalary>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoSalary dto)
        {
            var template = Mapper.Map<Salary>(dto);

            _context.Salaries.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoSalary dto, long id)
        {
            var template = Mapper.Map<Salary>(dto);

            template.Id = id;

            await _context.Salaries
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Salaries
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
