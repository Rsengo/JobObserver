using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Travel.Relocation;
using Resumes.Db.Dto.Models.Travel.Relocation;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class RelocationPossibilityController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public RelocationPossibilityController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.RelocationPossibilities
                .Include(x => x.RelocationType)
                .Include(x => x.Area)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoRelocationPossibility>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume([FromQuery]long id)
        {
            var result = await _context.RelocationPossibilities
                .Where(x => x.ResumeId == id)
                .Include(x => x.RelocationType)
                .Include(x => x.Area)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoRelocationPossibility>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoRelocationPossibility dto)
        {
            var entity = Mapper.Map<RelocationPossibility>(dto);
            _context.RelocationPossibilities.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoRelocationPossibility dto, [FromQuery]long id)
        {
            var template = Mapper.Map<RelocationPossibility>(dto);

            template.Id = id;

            await _context.RelocationPossibilities
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]long id)
        {
            await _context.RelocationPossibilities
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}