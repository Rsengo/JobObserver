using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Employments;
using Resumes.Db.Dto.Models.Employments;

namespace Resumes.API.Controllers
{
    [Route("api/v1/resumes")]
    public class EmploymentsController: ControllerBase
    {
        private readonly ResumesDbContext _context;

        public EmploymentsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("employments/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeEmployments
                .Include(x => x.Employment)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeEmployment>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/employments")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeEmployments
                .Where(x => x.ResumeId == id)
                .Include(x => x.Employment)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeEmployment>(result);

            return Ok(dto);
        }

        [HttpPost("employments")]
        public async Task<IActionResult> Post(DtoResumeEmployment dto)
        {
            var entity = Mapper.Map<ResumeEmployment>(dto);
            _context.ResumeEmployments.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("employments/{id}")]
        public async Task<IActionResult> Update(DtoResumeEmployment dto, long id)
        {
            var template = Mapper.Map<ResumeEmployment>(dto);

            template.Id = id;

            await _context.ResumeEmployments
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("employments/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeEmployments
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
