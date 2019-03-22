using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db;
using PaidServices.Dto.Models;
using System.Threading.Tasks;

namespace PaidServices.API.Controllers
{
    [Route("api/paidservices")]
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
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.EmployerPaidServices
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoEmployerPaidService>(result);

            return Ok(dto);
        }
    }
}
