using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Skills;
using Vacancies.Db.Dto.Models.Skills;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/vacancies")]
    public class SkillsController : ControllerBase
    {
        private readonly VacanciesDbContext _context;

        public SkillsController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("skills/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.VacancySkills
                .Include(x => x.Skill)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancySkill>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetByVacancy(long id)
        {
            var result = await _context.VacancySkills
                .Where(x => x.VacancyId == id)
                .Include(x => x.Skill)
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoVacancySkill>(result);

            return Ok(dto);
        }

        [HttpPost("skills")]
        public async Task<IActionResult> Post(DtoVacancySkill dto)
        {
            var entity = Mapper.Map<VacancySkill>(dto);
            _context.VacancySkills.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("skills/{id}")]
        public async Task<IActionResult> Update(DtoVacancySkill dto, long id)
        {
            var template = Mapper.Map<VacancySkill>(dto);

            template.Id = id;

            await _context.VacancySkills
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("skills/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.VacancySkills
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}