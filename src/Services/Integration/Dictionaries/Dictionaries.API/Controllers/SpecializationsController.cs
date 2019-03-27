using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.Db;
using Dictionaries.Dto.Models.Specializations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
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
        public async Task<IActionResult> Get(long id)
        {
            await _context.Specializations.LoadAsync();
            var result = await _context.Specializations.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoSpecializationSync>(result);

            return Ok(dto);
        }
    }
}
