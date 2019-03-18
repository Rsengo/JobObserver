using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Dto.Models.ResumeAreas;

namespace Resumes.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkTicketsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public WorkTicketsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.WorkTickets
                .Include(x => x.Area)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoWorkTicket>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.WorkTickets
                .Where(x => x.ResumeId == id)
                .Include(x => x.Area)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoWorkTicket>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoWorkTicket dto)
        {
            var entity = Mapper.Map<WorkTicket>(dto);
            _context.WorkTickets.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoWorkTicket dto, long id)
        {
            var template = Mapper.Map<WorkTicket>(dto);

            template.Id = id;

            await _context.WorkTickets
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.WorkTickets
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}