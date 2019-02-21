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

    [Route("api/[controller]")]
    public sealed class BrandedTemplatesController: ControllerBase
    {
        private readonly MongoDbContext _context;

        public BrandedTemplatesController(BrandedTemplatesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            BrandedTemplate template = null;

            await _context.ExecuteTransactionAsync(async db =>
            {
                var collection = db.GetCollection<BrandedTemplate>();
                var filter = Builders<BrandedTemplate>.Filter.Eq(x => x.Id, id);
                var query = await collection.FindAsync(filter)
                    .ConfigureAwait(false);
                template = await query.SingleOrDefaultAsync()
                    .ConfigureAwait(false);
            }).ConfigureAwait(false);

            var dto = Mapper.Map<DtoBrandedTemplate>(template);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DtoBrandedTemplate dto)
        {
            var template = Mapper.Map<BrandedTemplate>(dto);

            await _context.ExecuteTransactionAsync(db =>
            {
                var collection = db.GetCollection<BrandedTemplate>();
                return collection.InsertOneAsync(template);
            }).ConfigureAwait(false);

            return Ok(template.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DtoBrandedTemplate dto, long id)
        {
            var template = Mapper.Map<BrandedTemplate>(dto);
            template.Id = id;

            await _context.ExecuteTransactionAsync( async db =>
            {
                var collection = db.GetCollection<BrandedTemplate>();
                var filter = Builders<BrandedTemplate>.Filter.Eq(x => x.Id, id);
                await collection.ReplaceOneAsync(filter, template)
                    .ConfigureAwait(false);
            }).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _context.ExecuteTransactionAsync(async db =>
            {
                var collection = db.GetCollection<BrandedTemplate>();
                var filter = Builders<BrandedTemplate>.Filter.Eq(x => x.Id, id);
                await collection.DeleteOneAsync(filter)
                    .ConfigureAwait(false);
            }).ConfigureAwait(false);

            return Ok();
        }
    }
}
