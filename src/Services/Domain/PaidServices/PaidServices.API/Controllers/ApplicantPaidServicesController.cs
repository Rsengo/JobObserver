using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidServices.Db;
using PaidServices.Dto.Models;

namespace PaidServices.API.Controllers
{
    using PaidServices.API.Filters;

    [Route("api/v1/paidservices")]
    public class ApplicantPaidServicesController : ControllerBase
    {
        private readonly PaidServicesDbContext _context;

        public ApplicantPaidServicesController(PaidServicesDbContext context)
        {
            _context = context;
        }

        [HttpGet("applicant")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.ApplicantPaidServices
                .ToListAsync()
                .ConfigureAwait(false);
            var dto = result
                .Select(Mapper.Map<DtoApplicantPaidService>)
                .ToList();

            return Ok(dto);
        }

        [HttpGet("applicant/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.ApplicantPaidServices
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoApplicantPaidService>(result);

            return Ok(dto);
        }

        [HttpPost("applicant/search")]
        public async Task<IActionResult> Search(SearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filtered = await _context.ApplicantPaidServices
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoApplicantPaidService>).ToList();
            return Ok(result);
        }
    }
}
