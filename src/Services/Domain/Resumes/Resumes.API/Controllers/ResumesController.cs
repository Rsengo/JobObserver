﻿using System;
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

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        private readonly ISecurityManager _securityManager;

        public ResumesController(
            ResumesDbContext context,
            ISecurityManager securityManager)
        {
            _context = context;
            _securityManager = securityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
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

        [HttpPost]
        public async Task<IActionResult> Post(DtoResume dto)
        {
            var entity = Mapper.Map<Resume>(dto);

            entity.CreatedAt = DateTime.UtcNow;

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
            template.UpdatedAt = DateTime.UtcNow;

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
    }
}
