using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Dto.Models;
using EducationalInstitutions.Dto.Models.Synonyms;
using EducationalInstitutions.Synchronization.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.API.Controllers
{
    using EducationalInstitutions.API.Filters;

    [Route("api/v1/[controller]")]
    public class EducationalInstitutionsController : ControllerBase
    {
        private readonly EducationalInstitutionsDbContext _context;

        private readonly IEventBus _eventBus;

        public EducationalInstitutionsController(
            EducationalInstitutionsDbContext context, 
            IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.EducationalInstitutions
                .Include(x => x.Synonyms)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoEducationalInstitution>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filteredIds = await _context.EducationalInstitutionSynonyms
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .Select(x => x.EducationalInstitutionId)
                .Distinct()
                .ToListAsync();

            var filtered = await _context.EducationalInstitutions
                .Where(x => filteredIds.Contains(x.Id))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoEducationalInstitution>).ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoEducationalInstitution dto)
        {
            var entity = Mapper.Map<EducationalInstitution>(dto);
            _context.EducationalInstitutions.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            dto.Id = entity.Id;
            var @event = new EducationalInstitutionsChanged
            {
                Created = new List<DtoEducationalInstitution> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoEducationalInstitution dto, long id)
        {
            var template = Mapper.Map<EducationalInstitution>(dto);

            template.Id = id;

            await _context.EducationalInstitutions
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            dto.Id = id;
            var @event = new EducationalInstitutionsChanged
            {
                Updated = new List<DtoEducationalInstitution> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.EducationalInstitutions
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            var @event = new EducationalInstitutionsChanged
            {
                Deleted = new List<long> { id }
            };
            _eventBus.Publish(@event);

            return Ok();
        }

        [HttpGet("{educationalInstitutionId}/synonyms")]
        public async Task<IActionResult> GetSynonyms(long educationalInstitutionId)
        {
            var result = await _context.EducationalInstitutionSynonyms
                .SingleOrDefaultAsync(x => x.EducationalInstitutionId == educationalInstitutionId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducationalInstitutionSynonyms>(result);

            return Ok(dto);
        }

        [HttpPost("synonyms")]
        public async Task<IActionResult> PostSynonym(DtoEducationalInstitutionSynonyms dto)
        {
            var entity = Mapper.Map<EducationalInstitutionSynonyms>(dto);
            _context.EducationalInstitutionSynonyms.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("synonyms/{id}")]
        public async Task<IActionResult> UpdateSynonym(
            DtoEducationalInstitutionSynonyms dto, 
            long id)
        {
            var template = Mapper.Map<EducationalInstitutionSynonyms>(dto);

            template.Id = id;

            await _context.EducationalInstitutionSynonyms
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("synonyms/{id}")]
        public async Task<IActionResult> DeleteSynonym(long id)
        {
            await _context.EducationalInstitutionSynonyms
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{partnersId}/partners")]
        public async Task<IActionResult> GetPartners(long partnersId)
        {
            var result = await _context.Partners
                .SingleOrDefaultAsync(x => x.EducationalInstitutionId == partnersId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoPartners>(result);

            return Ok(dto);
        }

        [HttpPost("partners/{id}")]
        public async Task<IActionResult> PostPartner(DtoPartners dto)
        {
            var entity = Mapper.Map<Partners>(dto);
            _context.Partners.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            dto.Id = entity.Id;
            var @event = new PartnersChanged()
            {
                Created = new List<DtoPartners> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(entity.Id);
        }

        [HttpPut("partners/{id}")]
        public async Task<IActionResult> UpdatePartner(DtoPartners dto, long id)
        {
            var template = Mapper.Map<Partners>(dto);

            template.Id = id;

            await _context.Partners
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            dto.Id = id;
            var @event = new PartnersChanged()
            {
                Updated = new List<DtoPartners> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(id);
        }

        [HttpDelete("partners/{id}")]
        public async Task<IActionResult> DeletePartner(long id)
        {
            await _context.Partners
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            var @event = new PartnersChanged
            {
                Deleted = new List<long> { id }
            };
            _eventBus.Publish(@event);

            return Ok();
        }
    }
}
