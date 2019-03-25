using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using CareerDays.Db;
using CareerDays.Db.Models.Geographic;
using CareerDays.Dto.Models.Geographic;
using CareerDays.Synchronization.Events.Geographic;

namespace CareerDays.Synchronization.EventHandlers.Geographic
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
                    opt.IncludeGraph = true;
                });
        }
    }
}
