using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Specializations;
using Resumes.Dto.Models.Specializations;

namespace Resumes.API.Controllers
{
    [Route("api/resumes")]
    public class SpecializationsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public SpecializationsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("specializations/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeSpecializations
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSpecialization>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/specializations")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeSpecializations
                .Where(x => x.ResumeId == id)
                .Include(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSpecialization>(result);

            return Ok(dto);
        }

        [HttpPost("specializations")]
        public async Task<IActionResult> Post(DtoResumeSpecialization dto)
        {
            var entity = Mapper.Map<ResumeSpecialization>(dto);
            _context.ResumeSpecializations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("specializations/{id}")]
        public async Task<IActionResult> Update(DtoResumeSpecialization dto, long id)
        {
            var template = Mapper.Map<ResumeSpecialization>(dto);

            template.Id = id;

            await _context.ResumeSpecializations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("specializations/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeSpecializations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}