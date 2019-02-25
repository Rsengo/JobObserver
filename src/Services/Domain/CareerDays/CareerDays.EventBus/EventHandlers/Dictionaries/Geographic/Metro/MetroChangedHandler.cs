using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Db;
using CareerDays.Dto.Models.Geographic.Metro;
using CareerDays.EventBus.Events.Dictionaries.Geographic.Metro;

namespace CareerDays.EventBus.EventHandlers.Dictionaries.Geographic.Metro
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
            var entities = @event.Entities;

            await _context.BulkMergeAsync(
                entities,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
