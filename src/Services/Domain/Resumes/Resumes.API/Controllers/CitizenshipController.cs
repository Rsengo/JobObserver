using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.Security.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Db.Dto.Models.ResumeAreas;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CitizenshipController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly IAccessorFactory _accessorFactory;

        public CitizenshipController(
            ResumesDbContext context,
            IAccessorFactory accessorFactory)
        {
            _context = context;
            _accessorFactory = accessorFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Citizenship
                .Include(x => x.Area)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCitizenship>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.Citizenship
                .Where(x => x.ResumeId == id)
                .Include(x => x.Area)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCitizenship>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoCitizenship dto)
        {
            var entity = Mapper.Map<Citizenship>(dto);
            _context.Citizenship.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoCitizenship dto, long id)
        {
            var template = Mapper.Map<Citizenship>(dto);

            template.Id = id;

            await _context.Citizenship
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Citizenship
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
