using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Educations;
using Resumes.Db.Dto.Models.Educations;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public EducationsController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.Educations
                .Include(x => x.EducationalLevel)
                .Include(x => x.Specializations)
                    .ThenInclude(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume([FromQuery]long id)
        {
            var result = await _context.Educations
                .Where(x => x.ResumeId == id)
                .Include(x => x.EducationalLevel)
                .Include(x => x.Specializations)
                .ThenInclude(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoEducation dto)
        {
            var entity = Mapper.Map<Education>(dto);
            _context.Educations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoEducation dto, [FromQuery]long id)
        {
            var template = Mapper.Map<Education>(dto);

            template.Id = id;

            await _context.Educations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]long id)
        {
            await _context.Educations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{id}/specializations/")]
        public async Task<IActionResult> GetSpecializations([FromQuery]long id)
        {
            var result = await _context.EducationSpecializations
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpPost("specializations")]
        public async Task<IActionResult> PostSpecialization([FromBody]DtoEducationSpecialization dto)
        {
            var entity = Mapper.Map<EducationSpecialization>(dto);
            _context.EducationSpecializations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("specializations/{id}")]
        public async Task<IActionResult> UpdateSpecialization(
            [FromBody]DtoEducationSpecialization dto,
            [FromQuery]long id)
        {
            var template = Mapper.Map<EducationSpecialization>(dto);

            template.Id = id;

            await _context.EducationSpecializations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("specializations/{id}")]
        public async Task<IActionResult> DeleteSpecialization([FromQuery]long id)
        {
            await _context.EducationSpecializations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
