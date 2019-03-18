﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Educations;
using Resumes.Dto.Models.Educations;

namespace Resumes.API.Controllers
{
    [Route("api/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public EducationsController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Educations
                .Include(x => x.EducationalLevel)
                .Include(x => x.Specializations)
                    .ThenInclude(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpGet("byResume/{id}")]
        public async Task<IActionResult> GetByResume(long id)
        {
            var result = await _context.Educations
                .Where(x => x.ResumeId == id)
                .Include(x => x.EducationalLevel)
                .Include(x => x.Specializations)
                .ThenInclude(x => x.Specialization)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoEducation dto)
        {
            var entity = Mapper.Map<Education>(dto);
            _context.Educations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoEducation dto, long id)
        {
            var template = Mapper.Map<Education>(dto);

            template.Id = id;

            await _context.Educations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Educations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{id}/specializations/")]
        public async Task<IActionResult> GetSpecializations(long id)
        {
            var result = await _context.EducationSpecializations
                .Include(x => x.Specialization)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducation>(result);

            return Ok(dto);
        }

        [HttpPost("specializations")]
        public async Task<IActionResult> PostSpecialization(DtoEducationSpecialization dto)
        {
            var entity = Mapper.Map<EducationSpecialization>(dto);
            _context.EducationSpecializations.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("specializations/{id}")]
        public async Task<IActionResult> UpdateSpecialization(
            DtoEducationSpecialization dto, 
            long id)
        {
            var template = Mapper.Map<EducationSpecialization>(dto);

            template.Id = id;

            await _context.EducationSpecializations
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("specializations/{id}")]
        public async Task<IActionResult> DeleteSpecialization(long id)
        {
            await _context.EducationSpecializations
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
