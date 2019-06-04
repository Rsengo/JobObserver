using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Experiences;
using Resumes.Db.Dto.Models.Experiences;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public ExperiencesController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.Experiences
                //.Include(x => x.Industry)
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Industries.LoadAsync();

            var dto = Mapper.Map<DtoExperience>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume([FromQuery]long id)
        {
            var result = await _context.Experiences
                .Where(x => x.ResumeId == id)
                //.Include(x => x.Industry)
                .Include(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);

            await _context.Industries.LoadAsync();

            var dto = Mapper.Map<DtoExperience>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoExperience dto)
        {
            var entity = Mapper.Map<Experience>(dto);
            _context.Experiences.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoExperience dto, [FromQuery]long id)
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
        public async Task<IActionResult> Delete([FromQuery]long id)
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
