using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models;
using Resumes.Dto.Models;

namespace Resumes.API.Controllers
{
    [Route("api/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public ResumesController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Resumes
                .Include(x => x.Area)
                .Include(x => x.Applicant)
                .Include(x => x.BusinessTripReadiness)
                .Include(x => x.Certificates)
                .Include(x => x.Citizenship)
                .Include(x => x.DrivingLicenseTypes)
                .Include(x => x.Education)
                .Include(x => x.Employments)
                .Include(x => x.Experience)
                .Include(x => x.Languages)
                .Include(x => x.MetroStation)
                .Include(x => x.Negotiations)
                .Include(x => x.RelocationPossibility)
                .Include(x => x.ResumeLocale)
                .Include(x => x.ResumeStatus)
                .Include(x => x.Specializations)
                .Include(x => x.Salary)
                .Include(x => x.Schedules)
                .Include(x => x.Skills)
                .Include(x => x.TravelTime)
                .Include(x => x.WorkTicket)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResume>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoResume dto)
        {
            var entity = Mapper.Map<Resume>(dto);
            _context.Resumes.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoResume dto, long id)
        {
            var template = Mapper.Map<Resume>(dto);

            template.Id = id;

            await _context.Resumes
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Resumes
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
