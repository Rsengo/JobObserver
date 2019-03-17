using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Dto.Models;
using EducationalInstitutions.Dto.Models.Synonyms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.API.Controllers
{
    [Route("api/[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly EducationalInstitutionsDbContext _context;

        public FacultiesController(EducationalInstitutionsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Faculties
                .Include(x => x.Synonyms)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoFaculty>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoFaculty dto)
        {
            var entity = Mapper.Map<Faculty>(dto);
            _context.Faculties.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoFaculty dto, long id)
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
        public async Task<IActionResult> Delete(long id)
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
        public async Task<IActionResult> GetSynonyms(long facultyId)
        {
            var result = await _context.FacultySynonyms
                .SingleOrDefaultAsync(x => x.FacultyId == facultyId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoFacultySynonyms>(result);

            return Ok(dto);
        }

        [HttpPost("synonyms")]
        public async Task<IActionResult> PostSynonym(DtoFacultySynonyms dto)
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
            DtoFacultySynonyms dto,
            long id)
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
        public async Task<IActionResult> DeleteSynonym(long id)
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
