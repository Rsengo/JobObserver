using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employers.Db;
using Employers.Db.Models;
using Employers.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employers.API.Controllers
{
    public class DepartmentsController : ControllerBase
    {
        private readonly EmployersDbContext _context;

        public DepartmentsController(EmployersDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.Departments
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoDepartment>(result);

            return Ok(dto);
        }

        [HttpGet("byEmployer/{id}")]
        public async Task<IActionResult> GetByEmployer(long id)
        {
            var result = await _context.Departments
                .SingleOrDefaultAsync(x => x.OrganizationId == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoDepartment>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DtoDepartment dto)
        {
            var entity = Mapper.Map<Department>(dto);
            _context.Departments.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoDepartment dto, long id)
        {
            var template = Mapper.Map<Department>(dto);

            template.Id = id;

            await _context.Departments
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.Departments
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
