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
using CareerDays.Db.Dto.Models.Geographic.Metro;
using CareerDays.Db.Synchronization.Events.Geographic.Metro;

namespace CareerDays.Db.Synchronization.EventHandlers.Geographic.Metro
{
    public class MetroChangedHandler : 
        IIntegrationEventHandler<MetroChanged>
    {
        private readonly CareerDaysDbContext _context;

        public MetroChangedHandler(CareerDaysDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MetroChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Metro
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Db.Models.Geographic.Metro.Metro>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
