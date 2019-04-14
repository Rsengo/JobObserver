using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Models.Geographic;
using Resumes.Dto.Models;
using Resumes.Dto.Models.Geographic;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly ResumesDbContext _context;

        public AddressesController(ResumesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Addresses
                .Include(x => x.Area)
                .Include(x => x.Station)
                    .ThenInclude(x => x.Line)
                        .ThenInclude(x => x.Metro)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoAddress>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoAddress dto)
        {
            var template = Mapper.Map<Address>(dto);

            _context.Addresses.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoAddress dto, long id)
        {
            var template = Mapper.Map<Address>(dto);

            template.Id = id;

            await _context.Addresses
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Addresses
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
