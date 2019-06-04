using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.Db;
using Dictionaries.Db.Dto.Models.Specializations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
    using Dictionaries.API.Infrastructure.Filters;

    [Route("api/v1/[controller]")]
    public class SpecializationsController : ControllerBase
    {
        private readonly DictionariesDbContext _context;

        public SpecializationsController(DictionariesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Specializations.ToListAsync();
            var dto = result.Select(Mapper.Map<DtoSpecializationSync>).ToList();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            await _context.Specializations.LoadAsync();
            var result = await _context.Specializations.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoSpecializationSync>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var entities = await _context.Specializations.ToListAsync();

            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;
            var filtered = entities.Where(x => x.Name.Contains(filter.Template, comprassionMethod));

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value);

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value);

            var result = filtered.Select(Mapper.Map<DtoSpecialization>).ToList();
            return Ok(result);
        }
    }
}
