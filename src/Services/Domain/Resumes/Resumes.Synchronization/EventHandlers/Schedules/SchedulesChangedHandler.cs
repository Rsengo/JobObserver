using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Schedules;
using Resumes.Synchronization.Events.Schedules;

namespace Resumes.Synchronization.EventHandlers.Schedules
{
    public class SchedulesChangedHandler :
        IIntegrationEventHandler<SchedulesChanged>
    {
        private readonly ResumesDbContext _context;

        public SchedulesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SchedulesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Schedule>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
