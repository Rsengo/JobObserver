using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.Db;
using Dictionaries.Db.Dto.Models.Geographic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
    using Dictionaries.API.Infrastructure.Filters;
    using Dictionaries.Db.Models.Geographic;

    [Route("api/v1/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly DictionariesDbContext _context;

        public AreasController(DictionariesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Areas.ToListAsync();
            var dto = result.Select(Mapper.Map<DtoAreaSync>).ToList();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            await _context.Areas.LoadAsync();
            var result = await _context.Areas.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoAreaSync>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var entities = await _context.Areas.ToListAsync();

            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;
            var filtered = entities.Where(x => x.Name.Contains(filter.Template, comprassionMethod));

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value);

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value);

            var result = filtered.Select(Mapper.Map<DtoArea>).ToList();
            return Ok(result);
        }

        [HttpPost("search/cities")]
        public async Task<IActionResult> SearchCities([FromBody]SearchFilter filter)
        {
            var entities = await _context.Areas.ToListAsync();

            Func<Area, string> getCityNameDelegate = city =>
            {
                var parts = new List<string>() { city.Name };

                var tempArea = city;
                while (tempArea.Parent != null)
                {
                    tempArea = tempArea.Parent;
                    parts.Add(tempArea.Name);
                }

                parts.Reverse();
                var resultName = string.Join(", ", parts);
                return resultName;
            };

            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;
            var filtered = entities
                .Where(x => x.Areas?.Any() != true)
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .Select(x => new Area { Id = x.Id, Name = getCityNameDelegate(x) });

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value);

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value);

            return Ok(filtered);
        }

        [HttpPost("search/countries")]
        public async Task<IActionResult> SearchCountries([FromBody]SearchFilter filter)
        {
            var entities = await _context.Areas.ToListAsync();

            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;
            var filtered = entities
                .Where(x => x.Parent == null)
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod));

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value);

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value);

            var result = filtered.Select(Mapper.Map<DtoArea>).ToList();
            return Ok(result);
        }
    }
}
