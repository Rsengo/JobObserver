using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Db.Dto.Models;
using EducationalInstitutions.Db.Dto.Models.Synonyms;
using Microsoft.AspNetCore.Mvc;
using EducationalInstitutions.API.Filters;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly EducationalInstitutionsDbContext _context;

        public FacultiesController(EducationalInstitutionsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.Faculties
                .Include(x => x.Synonyms)
                .Include(x => x.BrandedDescription)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoFaculty>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]FacultySearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filteredIds = await _context.FacultySynonyms
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .Select(x => x.FacultyId)
                .Distinct()
                .ToListAsync();

            var filtered = await _context.Faculties
                .Include(x => x.Synonyms)
                .Include(x => x.BrandedDescription)
                .Where(x =>
                    filteredIds.Contains(x.Id) ||
                    x.Name.Contains(filter.Template, comprassionMethod) ||
                    x.Acronym.Contains(filter.Template, comprassionMethod))
                .Where(x => x.EducationalInstitutionId == filter.EducationalInstitutionId)
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoFaculty>).ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoFaculty dto)
        {
            var entity = Mapper.Map<Faculty>(dto);
            _context.Faculties.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoFaculty dto, [FromRoute]long id)
        {
            var template = Mapper.Map<Faculty>(dto);

            template.Id = id;

            await _context.Faculties
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _context.Faculties
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{facultyId}/synonyms")]
        public async Task<IActionResult> GetSynonyms([FromRoute]long facultyId)
        {
            var result = await _context.FacultySynonyms
                .SingleOrDefaultAsync(x => x.FacultyId == facultyId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoFacultySynonyms>(result);

            return Ok(dto);
        }

        [HttpPost("synonyms")]
        public async Task<IActionResult> PostSynonym([FromBody]DtoFacultySynonyms dto)
        {
            var entity = Mapper.Map<FacultySynonyms>(dto);
            _context.FacultySynonyms.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("synonyms/{id}")]
        public async Task<IActionResult> UpdateSynonym(
            [FromBody]DtoFacultySynonyms dto,
            [FromRoute]long id)
        {
            var template = Mapper.Map<FacultySynonyms>(dto);

            template.Id = id;

            await _context.FacultySynonyms
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("synonyms/{id}")]
        public async Task<IActionResult> DeleteSynonym([FromRoute]long id)
        {
            await _context.FacultySynonyms
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
