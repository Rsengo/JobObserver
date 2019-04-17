using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Employments;
using Vacancies.Db.Models.Geographic;
using Vacancies.Db.Synchronization.Events.Employments;

namespace Vacancies.Db.Synchronization.EventHandlers.Employments
{
    public class EmploymentsChangedHandler :
        IIntegrationEventHandler<EmploymentsChanged>
    {
        private readonly VacanciesDbContext _context;

        public EmploymentsChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmploymentsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Employments
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Employment>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}