using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Skills;
using Resumes.Db.Dto.Models.Skills;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/resumes")]
    public class SkillsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public SkillsController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("skills/{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.ResumeSkills
                .Include(x => x.Skill)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSkill>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetByResume([FromRoute]long id)
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
        public async Task<IActionResult> Post([FromBody]DtoResumeSkill dto)
        {
            var entity = Mapper.Map<ResumeSkill>(dto);
            _context.ResumeSkills.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("skills/{id}")]
        public async Task<IActionResult> Update([FromBody]DtoResumeSkill dto, [FromRoute]long id)
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
        public async Task<IActionResult> Delete([FromRoute]long id)
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