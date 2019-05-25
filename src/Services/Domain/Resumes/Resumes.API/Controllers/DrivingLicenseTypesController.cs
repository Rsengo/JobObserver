using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Driving;
using Resumes.Db.Dto.Models.Driving;
using BuildingBlocks.Security.Abstract;

namespace Resumes.API.Controllers
{
    [Route("api/v1/resumes")]
    public class DrivingLicenseTypesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public DrivingLicenseTypesController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ResumeDrivingLicenseTypes
                .Include(x => x.DrivingLicenseType)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeDrivingLicenseType>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/drivingLicenseTypes")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.ResumeDrivingLicenseTypes
                .Where(x => x.ResumeId == id)
                .Include(x => x.DrivingLicenseType)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoResumeDrivingLicenseType>(result);

            return Ok(dto);
        }

        [HttpPost("drivingLicenseTypes")]
        public async Task<IActionResult> Post(DtoResumeDrivingLicenseType dto)
        {
            var entity = Mapper.Map<ResumeDrivingLicenseType>(dto);
            _context.ResumeDrivingLicenseTypes.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Update(DtoResumeDrivingLicenseType dto, long id)
        {
            var template = Mapper.Map<ResumeDrivingLicenseType>(dto);

            template.Id = id;

            await _context.ResumeDrivingLicenseTypes
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("drivingLicenseTypes/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ResumeDrivingLicenseTypes
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
