using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Db;
using Vacancies.Db.Models.Languages;
using Vacancies.Dto.Models;
using Vacancies.Dto.Models.Languages;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    public class LanguageSkillsController : ControllerBase
    {
                private readonly VacanciesDbContext _context;

        public LanguageSkillsController(VacanciesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.LanguageSkills
                .AsDbQuery()
                .Include(x => x.Level)
                .Include(x => x.Language)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoLanguageSkill>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoLanguageSkill dto)
        {
            var template = Mapper.Map<LanguageSkill>(dto);

            _context.LanguageSkills.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoLanguageSkill dto, long id)
        {
            var template = Mapper.Map<LanguageSkill>(dto);

            template.Id = id;

            await _context.LanguageSkills
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.LanguageSkills
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
