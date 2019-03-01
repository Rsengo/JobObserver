using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Db;
using CareerDays.Db.Models.Geographic.Metro;
using CareerDays.Dto.Models.Geographic.Metro;
using CareerDays.Synchronization.Events.Geographic.Metro;

namespace CareerDays.Synchronization.EventHandlers.Geographic.Metro
{
    public class LinesChangedHandler : 
        IIntegrationEventHandler<LinesChanged>
    {
        private readonly CareerDaysDbContext _context;

        public LinesChangedHandler(CareerDaysDbContext context)
        {
            _context = context;
        }

        public async Task Handle(LinesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Lines
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Line>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true); 
        }
    }
}
