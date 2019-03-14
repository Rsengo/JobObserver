using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Employers;
using Vacancies.Synchronization.Events.Employers;

namespace Vacancies.Synchronization.EventHandlers.Employers
{
    public class EmployersChangedHandler :
        IIntegrationEventHandler<EmployersChanged>
    {
        private readonly VacanciesDbContext _context;

        public EmployersChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmployersChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Employer>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
