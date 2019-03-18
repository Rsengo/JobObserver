using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Experiences;
using Resumes.Dto.Models.Experiences;

namespace Resumes.API.Controllers
{
    [Route("api/[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public ExperiencesController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Experiences
                .Include(x => x.Industry)
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoExperience>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.Experiences
                .Where(x => x.ResumeId == id)
                .Include(x => x.Industry)
                .Include(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoExperience>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoExperience dto)
        {
            var entity = Mapper.Map<Experience>(dto);
            _context.Experiences.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoExperience dto, long id)
        {
            var template = Mapper.Map<Experience>(dto);

            template.Id = id;

            await _context.Experiences
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Experiences
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
