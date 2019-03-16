using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Industries;
using Resumes.Synchronization.Events.Applicants;
using Resumes.Synchronization.Events.Industries;

namespace Resumes.Synchronization.EventHandlers.Industries
{
    public class IndustriesChangedHandler :
        IIntegrationEventHandler<IndustriesChanged>
    {
        private readonly ResumesDbContext _context;

        public IndustriesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(IndustriesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Industries
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Industry>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}