using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Dto.Models.Schedules;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/resumes")]
    public class SchedulesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public SchedulesController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("schedules/{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.ResumeSchedules
                .Include(x => x.Schedule)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeSchedule>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/schedules")]
        public async Task<IActionResult> GetByResume([FromQuery]long id)
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
        public async Task<IActionResult> Post([FromBody]DtoResumeSchedule dto)
        {
            var entity = Mapper.Map<ResumeSchedule>(dto);
            _context.ResumeSchedules.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("schedules/{id}")]
        public async Task<IActionResult> Update([FromBody]DtoResumeSchedule dto, [FromQuery]long id)
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
        public async Task<IActionResult> Delete([FromQuery]long id)
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
