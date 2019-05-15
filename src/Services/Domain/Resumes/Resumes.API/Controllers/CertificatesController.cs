using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.Security.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Dto.Models.Certificates;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly IAccessorFactory _accessorFactory;

        public CertificatesController(
            ResumesDbContext context,
            IAccessorFactory accessorFactory)
        {
            _context = context;
            _accessorFactory = accessorFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Certificates
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            var accessor = _accessorFactory.Create(HttpContext.User);
            var allowed = accessor.HasPermission(result, AccessOperation.READ);

            var dto = Mapper.Map<DtoCertificate>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.Certificates
                .Where(x => x.ResumeId == id)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCertificate>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoCertificate dto)
        {
            var entity = Mapper.Map<Certificate>(dto);
            _context.Certificates.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoCertificate dto, long id)
        {
            var template = Mapper.Map<Certificate>(dto);

            template.Id = id;

            await _context.Certificates
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Certificates
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
