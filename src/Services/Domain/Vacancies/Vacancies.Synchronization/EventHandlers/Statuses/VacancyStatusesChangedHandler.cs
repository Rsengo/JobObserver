using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Statuses;
using Vacancies.Synchronization.Events.Statuses;

namespace Vacancies.Synchronization.EventHandlers.Statuses
{
    public class VacancyStatusesChangedHandler :
        IIntegrationEventHandler<VacancyStatusesChanged>
    {
        private readonly VacanciesDbContext _context;

        public VacancyStatusesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(VacancyStatusesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<VacancyStatus>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
