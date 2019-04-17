using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Schedules;
using Vacancies.Db.Synchronization.Events.Schedules;

namespace Vacancies.Db.Synchronization.EventHandlers.Schedules
{
    public class SchedulesChangedHandler :
        IIntegrationEventHandler<SchedulesChanged>
    {
        private readonly VacanciesDbContext _context;

        public SchedulesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SchedulesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Schedules
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
