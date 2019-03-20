using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaidServices.Db;
using PaidServices.Dto.Models;

namespace PaidServices.API.Controllers
{
    [Route("api/paidservices")]
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
                .ToListAsync();
            var dto = result.Select(Mapper.Map<DtoApplicantPaidService>).ToList();

            return Ok(dto);
        }
    }
}
