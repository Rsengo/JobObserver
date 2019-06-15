using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models;
using Resumes.Db.Dto.Models;
using BuildingBlocks.Security.Abstract;
using BuildingBlocks.Security;
using Resumes.API.Filters;
using Microsoft.EntityFrameworkCore.Query;
using LinqKit;
using System.Linq.Dynamic.Core;
using Resumes.API.Filters.Builders;
using Resumes.API.Services;
using Resumes.Export;
using System.Reflection;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        private readonly ResumeService _resumeService;

        private readonly IResumeExporter _exporter;

        public ResumesController(
            ResumesDbContext context,
            ISecurityManager securityManager,
            ResumeService resumeService,
            IResumeExporter exporter)
        {
            _context = context;
            _securityManager = securityManager;
            _resumeService = resumeService;
            _exporter = exporter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            //var allowed = await _securityManager.HasPermissionAsync(
            //    new Resume() { ApplicantId = Guid.Empty }, 
            //    AccessOperation.READ);

            var result = await _context.Resumes
                //.Include(x => x.Area)
                .Include(x => x.Applicant)
                    .ThenInclude(x => x.Gender)
                .Include(x => x.BusinessTripReadiness)
                .Include(x => x.Certificates)
                .Include(x => x.Citizenship)
                    .ThenInclude(x => x.Area)
                .Include(x => x.DrivingLicenseTypes)
                    .ThenInclude(x => x.DrivingLicenseType)
                .Include(x => x.Education)
                    //.AlsoInclude(x => x.EducationalLevel)
                    .ThenInclude(x => x.Specializations)
                        .ThenInclude(x => x.Specialization)
                .Include(x => x.Employments)
                    .ThenInclude(x => x.Employment)
                .Include(x => x.Experience)
                    .ThenInclude(x => x.Specialization)
                .Include(x => x.Languages)
                    //.AlsoInclude(x => x.Level)
                    //.AlsoInclude(x => x.Language)
                .Include(x => x.MetroStation)
                    .ThenInclude(x => x.Line)
                        .ThenInclude(x => x.Metro)
                .Include(x => x.RelocationPossibility)
                    .ThenInclude(x => x.RelocationType)
                .Include(x => x.ResumeLocale)
                .Include(x => x.ResumeStatus)
                .Include(x => x.Specializations)
                    //.ThenInclude(x => x.Specialization)
                .Include(x => x.Salary)
                    .ThenInclude(x => x.Currency)
                .Include(x => x.Schedules)
                    .ThenInclude(x => x.Schedule)
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.TravelTime)
                .Include(x => x.WorkTicket)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.EducationalLevels.LoadAsync();
            await _context.Specializations.LoadAsync();

            var dto = Mapper.Map<DtoResume>(result);

            return Ok(dto);
        }

        [HttpGet("byApplicant/{applicantId}")]
        public async Task<IActionResult> GetByApplicant([FromRoute]Guid applicantId)
        {
            var query = _context.Resumes
                //.Include(x => x.Area)
                .Include(x => x.Applicant)
                    .ThenInclude(x => x.Gender)
                .Include(x => x.BusinessTripReadiness)
                .Include(x => x.Certificates)
                .Include(x => x.Citizenship)
                    .ThenInclude(x => x.Area)
                .Include(x => x.DrivingLicenseTypes)
                    .ThenInclude(x => x.DrivingLicenseType)
                .Include(x => x.Education)
                    //.AlsoInclude(x => x.EducationalLevel)
                    .ThenInclude(x => x.Specializations)
                        .ThenInclude(x => x.Specialization)
                .Include(x => x.Employments)
                    .ThenInclude(x => x.Employment)
                .Include(x => x.Experience)
                    .ThenInclude(x => x.Specialization)
                .Include(x => x.Languages)
                //.AlsoInclude(x => x.Level)
                //.AlsoInclude(x => x.Language)
                .Include(x => x.MetroStation)
                    .ThenInclude(x => x.Line)
                        .ThenInclude(x => x.Metro)
                .Include(x => x.RelocationPossibility)
                    .ThenInclude(x => x.RelocationType)
                .Include(x => x.ResumeLocale)
                .Include(x => x.ResumeStatus)
                .Include(x => x.Specializations)
                //.ThenInclude(x => x.Specialization)
                .Include(x => x.Salary)
                    .ThenInclude(x => x.Currency)
                .Include(x => x.Schedules)
                    .ThenInclude(x => x.Schedule)
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.TravelTime)
                .Include(x => x.WorkTicket)
                    .ThenInclude(x => x.Area)
                 .Where(x => x.ApplicantId == applicantId);

            var allowed = await _securityManager.HasPermissionAsync(query, AccessOperation.READ);

            if (!allowed)
                return Forbid();

            var result = await query.ToListAsync();

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.EducationalLevels.LoadAsync();
            await _context.Specializations.LoadAsync();

            var dto = result.Select(Mapper.Map<DtoResume>).ToList();

            return Ok(dto);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination([FromBody]PaginationFilter filter)
        {
            var query = _context.Resumes
            //.Include(x => x.Area)
            .Include(x => x.Applicant)
                .ThenInclude(x => x.Gender)
            .Include(x => x.BusinessTripReadiness)
            .Include(x => x.Certificates)
            .Include(x => x.Citizenship)
                .ThenInclude(x => x.Area)
            .Include(x => x.DrivingLicenseTypes)
                .ThenInclude(x => x.DrivingLicenseType)
            .Include(x => x.Education)
                //.AlsoInclude(x => x.EducationalLevel)
                .ThenInclude(x => x.Specializations)
                    .ThenInclude(x => x.Specialization)
            .Include(x => x.Employments)
                .ThenInclude(x => x.Employment)
            .Include(x => x.Experience)
                .ThenInclude(x => x.Specialization)
            .Include(x => x.Languages)
            //.AlsoInclude(x => x.Level)
            //.AlsoInclude(x => x.Language)
            .Include(x => x.MetroStation)
                .ThenInclude(x => x.Line)
                    .ThenInclude(x => x.Metro)
            .Include(x => x.RelocationPossibility)
                .ThenInclude(x => x.RelocationType)
            .Include(x => x.ResumeLocale)
            .Include(x => x.Specializations)
            //.ThenInclude(x => x.Specialization)
            .Include(x => x.Salary)
                .ThenInclude(x => x.Currency)
            .Include(x => x.Schedules)
                .ThenInclude(x => x.Schedule)
            .Include(x => x.Skills)
                .ThenInclude(x => x.Skill)
            .Include(x => x.TravelTime)
            .Include(x => x.WorkTicket)
                .ThenInclude(x => x.Area)
            .Include(x => x.ResumeStatus)
            .Skip(filter.Offset)
            .Take(filter.Count);

            var allowed = await _securityManager.HasPermissionAsync(query, AccessOperation.READ);

            if (!allowed)
                return Forbid();

            var result = await query.ToListAsync();

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.EducationalLevels.LoadAsync();
            await _context.Specializations.LoadAsync();

            var dto = result.Select(Mapper.Map<DtoResume>).ToList();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoResume dto)
        {
            var entity = Mapper.Map<Resume>(dto);

            entity.CreatedAt = DateTime.UtcNow;
            entity.IsPremium = false;

            _context.Resumes.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoResume dto, [FromRoute]long id)
        {
            var template = Mapper.Map<Resume>(dto);
            template.UpdatedAt = DateTime.UtcNow;
            template.CreatedAt = DateTime.UtcNow;
            template.IsPremium = false;

            template.Id = id;

            await _context.Resumes
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            var result = _context.Resumes
                .Select(x => new Resume { Id = x.Id, ApplicantId = x.ApplicantId })
                .SingleOrDefault(x => x.Id == id);

            await _context.Resumes
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] ResumeSearchFilter filter)
        {
            var builder = new ResumeSearchBuilder(_context);
            var query = builder.BuildQuery(filter);

            var includableQuery = query
            //.Include(x => x.Area)
            .Include(x => x.Applicant)
                .ThenInclude(x => x.Gender)
            .Include(x => x.BusinessTripReadiness)
            .Include(x => x.Certificates)
            .Include(x => x.Citizenship)
                .ThenInclude(x => x.Area)
            .Include(x => x.DrivingLicenseTypes)
                .ThenInclude(x => x.DrivingLicenseType)
            .Include(x => x.Education)
                //.AlsoInclude(x => x.EducationalLevel)
                .ThenInclude(x => x.Specializations)
                    .ThenInclude(x => x.Specialization)
            .Include(x => x.Employments)
                .ThenInclude(x => x.Employment)
            .Include(x => x.Experience)
                .ThenInclude(x => x.Specialization)
            .Include(x => x.Languages)
            //.AlsoInclude(x => x.Level)
            //.AlsoInclude(x => x.Language)
            .Include(x => x.MetroStation)
                .ThenInclude(x => x.Line)
                    .ThenInclude(x => x.Metro)
            .Include(x => x.RelocationPossibility)
                .ThenInclude(x => x.RelocationType)
            .Include(x => x.ResumeLocale)
            .Include(x => x.Specializations)
            //.ThenInclude(x => x.Specialization)
            .Include(x => x.Salary)
                .ThenInclude(x => x.Currency)
            .Include(x => x.Schedules)
                .ThenInclude(x => x.Schedule)
            .Include(x => x.Skills)
                .ThenInclude(x => x.Skill)
            .Include(x => x.TravelTime)
            .Include(x => x.WorkTicket)
                .ThenInclude(x => x.Area)
            .Include(x => x.ResumeStatus);

            var allowed = await _securityManager.HasPermissionAsync(includableQuery, AccessOperation.READ);

            if (!allowed)
                return Forbid();

            var result = await includableQuery.ToListAsync();

            await _context.Areas.LoadAsync();
            await _context.Languages.LoadAsync();
            await _context.LanguageLevels.LoadAsync();
            await _context.EducationalLevels.LoadAsync();
            await _context.Specializations.LoadAsync();

            var dto = result.Select(Mapper.Map<DtoResume>).ToList();

            return Ok(dto);
        }
    }
}
