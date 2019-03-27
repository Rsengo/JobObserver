using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.Db;
using Dictionaries.Dto.Models.Geographic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
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
        public async Task<IActionResult> Get(long id)
        {
            await _context.Areas.LoadAsync();
            var result = await _context.Areas.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoAreaSync>(result);

            return Ok(dto);
        }
    }
}
