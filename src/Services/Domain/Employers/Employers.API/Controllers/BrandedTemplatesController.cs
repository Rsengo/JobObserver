using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employers.Db;
using Employers.Db.Models;

namespace Employers.API.Controllers
{
    using System.Linq;

    using AutoMapper;

    using Employers.Db.Dto.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/v1/[controller]")]
    public sealed class BrandedTemplatesController: ControllerBase
    {
        private readonly EmployersDbContext _context;

        public BrandedTemplatesController(EmployersDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var result = await _context.BrandedTemplates
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoBrandedTemplate>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]DtoBrandedTemplate dto)
        {
            var template = Mapper.Map<BrandedTemplate>(dto);
            _context.BrandedTemplates.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]DtoBrandedTemplate dto, [FromRoute]long id)
        {
            var template = Mapper.Map<BrandedTemplate>(dto);
            template.Id = id;

            await _context.BrandedTemplates
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(x => template)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _context.BrandedTemplates
                .Where(x => x.Id == id)
                .DeleteFromQueryAsync()
                .ConfigureAwait(false);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
