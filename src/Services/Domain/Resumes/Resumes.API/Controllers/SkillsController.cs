using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Skills;
using Resumes.Dto.Models.Skills;

namespace Resumes.API.Controllers
{
    [Route("api/resumes")]
    public class SkillsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public SkillsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("skills/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeSkills
                .Include(x => x.Skill)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSkill>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeSkills
                .Where(x => x.ResumeId == id)
                .Include(x => x.Skill)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSkill>(result);

            return Ok(dto);
        }

        [HttpPost("skills")]
        public async Task<IActionResult> Post(DtoResumeSkill dto)
        {
            var entity = Mapper.Map<ResumeSkill>(dto);
            _context.ResumeSkills.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("skills/{id}")]
        public async Task<IActionResult> Update(DtoResumeSkill dto, long id)
        {
            var template = Mapper.Map<ResumeSkill>(dto);

            template.Id = id;

            await _context.ResumeSkills
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("skills/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeSkills
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}