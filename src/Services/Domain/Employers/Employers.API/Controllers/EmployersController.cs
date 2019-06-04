using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Models;
using Employers.Db.Models.Synonyms;
using Employers.Db.Dto.Models;
using Employers.Db.Dto.Models.Synonyms;
using Employers.Db.Synchronization.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employers.API.Controllers
{
    using Employers.API.Filters;

    [Route("api/v1/[controller]")]
    public class EmployersController : ControllerBase
    {
        private readonly EmployersDbContext _context;

        private readonly IEventBus _eventBus;

        public EmployersController(
            EmployersDbContext context, 
            IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.Employers
                .Include(x => x.Type)
                .Include(x => x.Synonyms)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoEmployer>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filteredIds = await _context.EmployerSynonyms
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .Select(x => x.EmployerId)
                .Distinct()
                .ToListAsync();

            var filtered = await _context.Employers
                .Where(x =>
                    filteredIds.Contains(x.Id) ||
                    x.Name.Contains(filter.Template, comprassionMethod) ||
                    x.Acronym.Contains(filter.Template, comprassionMethod))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoEmployer>).ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoEmployer dto)
        {
            var entity = Mapper.Map<Employer>(dto);
            _context.Employers.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            dto.Id = entity.Id;
            var @event = new EmployersChanged
            {
                Created = new List<DtoEmployer> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoEmployer dto, [FromQuery]long id)
        {
            var template = Mapper.Map<Employer>(dto);

            template.Id = id;

            await _context.Employers
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            dto.Id = id;
            var @event = new EmployersChanged
            {
                Updated = new List<DtoEmployer> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]long id)
        {
            await _context.Employers
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            var @event = new EmployersChanged
            {
                Deleted = new List<long> { id }
            };
            _eventBus.Publish(@event);

            return Ok();
        }

        [HttpGet("{EmployerId}/synonyms")]
        public async Task<IActionResult> GetSynonyms([FromQuery]long EmployerId)
        {
            var result = await _context.EmployerSynonyms
                .SingleOrDefaultAsync(x => x.EmployerId == EmployerId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEmployerSynonyms>(result);

            return Ok(dto);
        }

        [HttpPost("synonyms")]
        public async Task<IActionResult> PostSynonym([FromBody]DtoEmployerSynonyms dto)
        {
            var entity = Mapper.Map<EmployerSynonyms>(dto);
            _context.EmployerSynonyms.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("synonyms/{id}")]
        public async Task<IActionResult> UpdateSynonym(
            [FromBody]DtoEmployerSynonyms dto,
            [FromQuery]long id)
        {
            var template = Mapper.Map<EmployerSynonyms>(dto);

            template.Id = id;

            await _context.EmployerSynonyms
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("synonyms/{id}")]
        public async Task<IActionResult> DeleteSynonym([FromQuery]long id)
        {
            await _context.EmployerSynonyms
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{partnersId}/partners")]
        public async Task<IActionResult> GetPartners([FromQuery]long partnersId)
        {
            var result = await _context.Partners
                .SingleOrDefaultAsync(x => x.EmployerId == partnersId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoPartners>(result);

            return Ok(dto);
        }

        [HttpPost("partners/{id}")]
        public async Task<IActionResult> PostPartner([FromBody]DtoPartners dto)
        {
            var entity = Mapper.Map<Partners>(dto);
            _context.Partners.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            dto.Id = entity.Id;
            var @event = new PartnersChanged
            {
                Created = new List<DtoPartners> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(entity.Id);
        }

        [HttpPut("partners/{id}")]
        public async Task<IActionResult> UpdatePartner([FromBody]DtoPartners dto, [FromQuery]long id)
        {
            var template = Mapper.Map<Partners>(dto);

            template.Id = id;

            await _context.Partners
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            dto.Id = id;
            var @event = new PartnersChanged
            {
                Updated = new List<DtoPartners> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(id);
        }

        [HttpDelete("partners/{id}")]
        public async Task<IActionResult> DeletePartner([FromQuery]long id)
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
