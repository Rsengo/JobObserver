using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Schedules;
using Resumes.Dto.Models.Schedules;

namespace Resumes.API.Controllers
{
    [Route("api/resumes")]
    public class SchedulesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public SchedulesController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("schedules/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeSchedules
                .Include(x => x.Schedule)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSchedule>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/schedules")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeSchedules
                .Where(x => x.ResumeId == id)
                .Include(x => x.Schedule)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSchedule>(result);

            return Ok(dto);
        }

        [HttpPost("Schedules")]
        public async Task<IActionResult> Post(DtoResumeSchedule dto)
        {
            var entity = Mapper.Map<ResumeSchedule>(dto);
            _context.ResumeSchedules.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("schedules/{id}")]
        public async Task<IActionResult> Update(DtoResumeSchedule dto, long id)
        {
            var template = Mapper.Map<ResumeSchedule>(dto);

            template.Id = id;

            await _context.ResumeSchedules
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("schedules/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeSchedules
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
