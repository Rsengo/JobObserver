using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Models;
using Employers.Db.Dto.Models;
using Employers.Db.Synchronization.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employers.API.Controllers
{
    using Employers.API.Filters;

    [Route("api/v1/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly EmployersDbContext _context;

        private readonly IEventBus _eventBus;

        public DepartmentsController(
            EmployersDbContext context, 
            IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]long id)
        {
            var result = await _context.Departments
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoDepartment>(result);

            return Ok(dto);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]DepartmentSearchFilter filter)
        {
            var comprassionMethod = filter.CaseSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            var filtered = await _context.Departments
                .Where(x => x.Name.Contains(filter.Template, comprassionMethod))
                .Where(x => x.OrganizationId == filter.EmployerId)
                .ToListAsync();

            if (filter.Offset != null)
                filtered = filtered.Skip(filter.Offset.Value).ToList();

            if (filter.Count != null)
                filtered = filtered.Take(filter.Count.Value).ToList();

            var result = filtered.Select(Mapper.Map<DtoDepartment>).ToList();
            return Ok(result);
        }

        [HttpGet("byEmployer/{id}")]
        public async Task<IActionResult> GetByEmployer([FromQuery]long id)
        {
            var result = await _context.Departments
                .SingleOrDefaultAsync(x => x.OrganizationId == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoDepartment>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DtoDepartment dto)
        {
            var entity = Mapper.Map<Department>(dto);
            _context.Departments.Add(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            dto.Id = entity.Id;
            var @event = new DepartmentsChanged
            {
                Created = new List<DtoDepartment> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(entity.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoDepartment dto, [FromQuery]long id)
        {
            var template = Mapper.Map<Department>(dto);

            template.Id = id;

            await _context.Departments
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(_ => template)
                .ConfigureAwait(false);

            dto.Id = id;
            var @event = new DepartmentsChanged
            {
                Updated = new List<DtoDepartment> { dto }
            };
            _eventBus.Publish(@event);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]long id)
        {
            await _context.Departments
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            var @event = new DepartmentsChanged
            {
                Deleted = new List<long> { id }
            };
            _eventBus.Publish(@event);

            return Ok();
        }
    }
}
