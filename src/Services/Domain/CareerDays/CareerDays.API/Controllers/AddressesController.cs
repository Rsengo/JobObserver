using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.API.Controllers
{
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly CareerDaysDbContext _context;

        public AddressesController(CareerDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Addresses
                .Include(x => x.Area)
                .Include(x => x.Station)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byCareerDay/{id}")]
        public async Task<IActionResult> GetByArea(long id)
        {
            var result = await _context.CareerDays
                .Include(x => x.EducationalInstitution)
                .Include(x => x.Employer)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.Address.AreaId == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoCareerDay dto)
        {
            var template = Mapper.Map<CareerDay>(dto);

            _context.CareerDays.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoCareerDay dto, long id)
        {
            var template = Mapper.Map<CareerDay>(dto);

            template.Id = id;

            await _context.CareerDays
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.CareerDays
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
