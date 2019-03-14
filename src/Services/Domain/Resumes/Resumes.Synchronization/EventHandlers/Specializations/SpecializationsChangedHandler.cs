using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Specializations;
using Resumes.Synchronization.Events.Specializations;

namespace Resumes.Synchronization.EventHandlers.Specializations
{
    public class SpecializationsChangedHandler :
        IIntegrationEventHandler<SpecializationsChanged>
    {
        private readonly ResumesDbContext _context;

        public SpecializationsChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SpecializationsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Specialization>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
