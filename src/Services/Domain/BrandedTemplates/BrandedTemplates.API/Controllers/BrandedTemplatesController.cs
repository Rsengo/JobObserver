using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrandedTemplates.Db;
using BrandedTemplates.Db.Models;
using BuildingBlocks.MongoDB;
using BuildingBlocks.Extensions.MongoDB;
using MongoDB.Driver;

namespace BrandedTemplates.API.Controllers
{
    using AutoMapper;

    using BrandedTemplates.Dto.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    public sealed class BrandedTemplatesController: ControllerBase
    {
        private readonly BrandedTemplatesDbContext _context;

        public BrandedTemplatesController(BrandedTemplatesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] long id)
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
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoBrandedTemplate dto, long id)
        {
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            
        }
    }
}
