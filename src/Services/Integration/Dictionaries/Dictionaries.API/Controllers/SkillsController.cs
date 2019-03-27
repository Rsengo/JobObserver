using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Skills;
using Dictionaries.Dto.Models.Skills;
using Dictionaries.EventBus.Events.Skills;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly DictionariesDbContext _context;

        private readonly IEventBus _eventBus;

        public SkillsController(
            DictionariesDbContext context,
            IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Skills.ToListAsync();
            var dto = result.Select(Mapper.Map<DtoSkill>).ToList();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Skills.SingleOrDefaultAsync(x => x.Id == id);
            var dto = Mapper.Map<DtoSkill>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoSkill dto)
        {
            var result = Mapper.Map<Skill>(dto);

            _context.Skills.Add(result);
            await _context.SaveChangesAsync();

            dto.Id = result.Id;
            var @event = new SkillsChanged
            {
                Created = new List<DtoSkill> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(result.Id);
        }
    }
}