using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using Resumes.Db;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Dto.Models.Geographic;
using Resumes.Db.Synchronization.Events.Geographic;

namespace Resumes.Db.Synchronization.EventHandlers.Geographic
{
    public class AreasChangedHandler : IIntegrationEventHandler<AreasChanged>
    {
        private readonly ResumesDbContext _context;

        public AreasChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AreasChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Area>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt =>
                {
                    opt.MergeKeepIdentity = true;
                    opt.IncludeGraph = false;
                });
        }
    }
}
