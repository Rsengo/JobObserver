using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db;
using PaidServices.Dto.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PaidServices.API.Controllers
{
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
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.EducationalInstitutionPaidServices
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEducationalInstitutionPaidService>(result);

            return Ok(dto);
        }
    }
}
