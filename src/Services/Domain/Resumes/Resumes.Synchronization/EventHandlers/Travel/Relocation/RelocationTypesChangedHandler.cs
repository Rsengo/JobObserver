using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Travel.Relocation;
using Resumes.Synchronization.Events.Travel.Relocation;

namespace Resumes.Synchronization.EventHandlers.Travel.Relocation
{
    public class RelocationTypesChangedHandler: IIntegrationEventHandler<RelocationTypesChanged>
    {
        private readonly ResumesDbContext _context;

        public RelocationTypesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RelocationTypesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.RelocationTypes
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<RelocationType>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
