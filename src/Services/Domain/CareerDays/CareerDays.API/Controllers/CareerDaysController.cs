﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.API.Controllers
{
    [Route("api/[controller]")]
    public class CareerDaysController : ControllerBase
    {
        private readonly CareerDaysDbContext _context;

        public CareerDaysController(CareerDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.CareerDays
                .Include(x => x.EducationalInstitution)
                .Include(x => x.Employer)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byEmployer/{employerId}")]
        public async Task<IActionResult> GetByEmployer(long employerId)
        {
            var result = await _context.CareerDays
                .Include(x => x.EducationalInstitution)
                .Include(x => x.Employer)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.EmployerId == employerId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byEducationalInstitution/{educationalInstitutionId}")]
        public async Task<IActionResult> GetByEducationalInstitution(long educationalInstitutionId)
        {
            var result = await _context.CareerDays
                .Include(x => x.EducationalInstitution)
                .Include(x => x.Employer)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.EducationalInstitutionId == educationalInstitutionId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpGet("byArea/{areaId}")]
        public async Task<IActionResult> GetByArea(long areaId)
        {
            var result = await _context.CareerDays
                .Include(x => x.EducationalInstitution)
                .Include(x => x.Employer)
                .Include(x => x.Address)
                    .ThenInclude(x => x.Area)
                .SingleOrDefaultAsync(x => x.Address.AreaId == areaId)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoCareerDay>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoCareerDay dto)
        {
            var template = Mapper.Map<CareerDay>(dto);
            var address = Mapper.Map<Address>(dto.Address);

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            template.AddressId = address.Id;
            _context.CareerDays.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoCareerDay dto, long id)
        {
            var template = Mapper.Map<CareerDay>(dto);

            if (dto.Address != null)
            {
                var address = Mapper.Map<Address>(dto.Address);
                address.Id = dto.AddressId;
                await _context.Addresses
                    .Where(x => x.Id == dto.AddressId)
                    .UpdateFromQueryAsync(_ => address)
                    .ConfigureAwait(false);
            }

            template.Id = id;

            await _context.CareerDays
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok();
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
