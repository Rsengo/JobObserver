using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Db.Dto.Models;
using CareerDays.Db.Dto.Models.Geographic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly CareerDaysDbContext _context;

        public AddressesController(CareerDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.Addresses
                .Include(x => x.Station)
                    .ThenInclude(x => x.Line)
                        .ThenInclude(x => x.Metro)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            await _context.Areas.LoadAsync();

            var dto = Mapper.Map<DtoAddress>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]DtoAddress dto)
        {
            var template = Mapper.Map<Address>(dto);

            _context.Addresses.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoAddress dto, [FromRoute]long id)
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
        public async Task<IActionResult> Delete([FromRoute]long id)
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
