using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.Db;
using Dictionaries.Db.Dto.Models.Industries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
    using Dictionaries.API.Infrastructure.Filters;

    [Route("api/v1/[controller]")]
    public class IndustriesController : ControllerBase
    {
        private readonly DictionariesDbContext _context;

        public IndustriesController(DictionariesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Industries.ToListAsync();
            var dto = result.Select(Mapper.Map<DtoIndustrySync>).ToList();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            await _context.Industries.LoadAsync();
            var result = await _context.Industries.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoIndustrySync>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchFilter filter)
        {
            var entities = await _context.Industries.ToListAsync();

            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;
            var filtered = entities.Where(x => x.Name.Contains(filter.Template, comprassionMethod));

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value);

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value);

            var result = filtered.Select(Mapper.Map<DtoIndustry>).ToList();
            return Ok(result);
        }
    }
}
