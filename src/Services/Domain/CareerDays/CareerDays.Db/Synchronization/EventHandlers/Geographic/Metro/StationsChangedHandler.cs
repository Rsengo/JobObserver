﻿using System;
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
using CareerDays.Db.Synchronization.Events.Geographic;
using CareerDays.Db.Synchronization.Events.Geographic.Metro;

namespace CareerDays.Db.Synchronization.EventHandlers.Geographic.Metro
{
    public class StationsChangedHandler : 
        IIntegrationEventHandler<StationsChanged>
    {
        private readonly CareerDaysDbContext _context;

        public StationsChangedHandler(CareerDaysDbContext context)
        {
            _context = context;
        }

        public async Task Handle(StationsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Stations
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Station>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
