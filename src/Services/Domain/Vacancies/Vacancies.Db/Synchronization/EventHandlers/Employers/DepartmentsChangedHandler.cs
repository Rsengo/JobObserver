using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models;
using Vacancies.Db.Models.Employers;
using Vacancies.Db.Synchronization.Events;
using Vacancies.Db.Synchronization.Events.Employers;

namespace Vacancies.Db.Synchronization.EventHandlers.Employers
{
    class DepartmentsChangedHandler :
        IIntegrationEventHandler<DepartmentsChanged>
    {
        private readonly VacanciesDbContext _context;

        public DepartmentsChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DepartmentsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Departments
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Department>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
