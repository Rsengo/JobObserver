using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db;
using PaidServices.Db.Dto.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PaidServices.API.Controllers
{
    using System;

    using PaidServices.API.Filters;

    public class EducationalInstitutionPaidServicesController : ControllerBase
    {
        private readonly PaidServicesDbContext _context;

        public EducationalInstitutionPaidServicesController(PaidServicesDbContext context)
        {
            _context = context;
        }

        [HttpGet("educationalInstitution")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.EducationalInstitutionPaidServices
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = result
                .Select(Mapper.Map<DtoEducationalInstitutionPaidService>)
                .ToList();

            return Ok(dto);
        }

        [HttpGet("educationalInstitution/{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.EducationalInstitutionPaidServices
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducationalInstitutionPaidService>(result);

            return Ok(dto);
        }

        [HttpPost("educationalInstitution/search")]
        public async Task<IActionResult> Search([FromBody]SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filtered = await _context.EducationalInstitutionPaidServices
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoEducationalInstitutionPaidService>).ToList();
            return Ok(result);
        }
    }
}
