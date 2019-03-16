using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Travel;
using Resumes.Synchronization.Events.Travel;

namespace Resumes.Synchronization.EventHandlers.Travel
{
    public class TravelTimesChangedHandler : IIntegrationEventHandler<TravelTimesChanged>
    {
        private readonly ResumesDbContext _context;

        public TravelTimesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TravelTimesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.TravelTimes
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<TravelTime>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
