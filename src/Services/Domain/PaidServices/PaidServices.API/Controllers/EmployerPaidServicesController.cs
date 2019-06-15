using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db;
using PaidServices.Db.Dto.Models;
using System.Threading.Tasks;

namespace PaidServices.API.Controllers
{
    using System;

    using PaidServices.API.Filters;

    [Route("api/v1/paidservices")]
    public class EmployerPaidServicesController : ControllerBase
    {
        private readonly PaidServicesDbContext _context;

        public EmployerPaidServicesController(PaidServicesDbContext context)
        {
            _context = context;
        }

        [HttpGet("employer")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.EmployerPaidServices
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = result
                .Select(Mapper.Map<DtoEmployerPaidService>)
                .ToList();

            return Ok(dto);
        }

        [HttpGet("employer/{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.EmployerPaidServices
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEmployerPaidService>(result);

            return Ok(dto);
        }

        [HttpPost("employer/search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filtered = await _context.EmployerPaidServices
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoEmployerPaidService>).ToList();
            return Ok(result);
        }
    }
}
