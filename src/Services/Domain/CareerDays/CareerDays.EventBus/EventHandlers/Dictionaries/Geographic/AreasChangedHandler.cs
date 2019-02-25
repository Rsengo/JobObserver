using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using CareerDays.Db;
using CareerDays.Dto.Models.Geographic;
using CareerDays.EventBus.Events.Dictionaries.Geographic;

namespace CareerDays.EventBus.EventHandlers.Dictionaries.Geographic
{
    public class AreasChangedHandler : IIntegrationEventHandler<AreasChanged>
    {
        private readonly CareerDaysDbContext _context;

        public AreasChangedHandler(CareerDaysDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AreasChanged @event)
        {
            var entities = @event.Entities;

            await _context.BulkMergeAsync(
                entities, 
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
