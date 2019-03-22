using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Negotiations;
using Resumes.Dto.Models.Negotiations;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class NegotiationsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public NegotiationsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeNegotiations
                .Include(x => x.Response)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeNegotiation>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeNegotiations
                .Where(x => x.ResumeId == id)
                .Include(x => x.Response)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeNegotiation>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoResumeNegotiation dto)
        {
            var entity = Mapper.Map<ResumeNegotiation>(dto);
            _context.ResumeNegotiations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoResumeNegotiation dto, long id)
        {
            var template = Mapper.Map<ResumeNegotiation>(dto);

            template.Id = id;

            await _context.ResumeNegotiations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeNegotiations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
