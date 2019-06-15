using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Dto.Models.Certificates;
using BuildingBlocks.Security.Abstract;
using BuildingBlocks.Security;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public CertificatesController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.Certificates
                .SingleOrDefaultAsync(x => x.Id == id);

            var allowed = await _securityManager.HasPermissionAsync(result, AccessOperation.READ);

            if (!allowed)
                return Forbid();

            var dto = Mapper.Map<DtoCertificate>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume([FromRoute]long id)
        {
            var query = _context.Certificates
                .Where(x => x.ResumeId == id);

            var allowed = await _securityManager.HasPermissionAsync(query, AccessOperation.READ);

            if (!allowed)
                return Forbid();

            var result = await query.ToListAsync();

            var dto = Mapper.Map<DtoCertificate>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoCertificate dto)
        {
            var entity = Mapper.Map<Certificate>(dto);

            var allowed = await _securityManager.HasPermissionAsync(entity, AccessOperation.CREATE);

            if (!allowed)
                return Forbid();

            _context.Certificates.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoCertificate dto, [FromRoute]long id)
        {
            var template = Mapper.Map<Certificate>(dto);

            template.Id = id;

            var allowed = await _securityManager.HasPermissionAsync(template, AccessOperation.UPDATE);

            if (!allowed)
                return Forbid();

            await _context.Certificates
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            var query = _context.Certificates
                .Where(x => x.Id == id);

            var allowed = await _securityManager.HasPermissionAsync(query, AccessOperation.UPDATE);

            if (!allowed)
                return Forbid();

            await query
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
