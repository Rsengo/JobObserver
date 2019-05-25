using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;

namespace EducationalInstitutions.API.Controllers
{
    using System.Linq;

    using AutoMapper;

    using EducationalInstitutions.Db.Dto.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/v1/[controller]")]
    public sealed class BrandedTemplatesController: ControllerBase
    {
        private readonly EducationalInstitutionsDbContext _context;

        public BrandedTemplatesController(EducationalInstitutionsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _context.BrandedTemplates
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
            var dto = Mapper.Map<DtoBrandedTemplate>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoBrandedTemplate dto)
        {
            var template = Mapper.Map<BrandedTemplate>(dto);
            _context.BrandedTemplates.Add(template);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoBrandedTemplate dto, long id)
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
        public async Task<IActionResult> Delete(long id)
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
