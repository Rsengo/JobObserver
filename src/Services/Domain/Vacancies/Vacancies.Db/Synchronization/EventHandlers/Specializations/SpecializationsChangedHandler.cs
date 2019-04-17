using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Specializations;
using Vacancies.Db.Synchronization.Events.Specializations;

namespace Vacancies.Db.Synchronization.EventHandlers.Specializations
{
    public class SpecializationsChangedHandler :
        IIntegrationEventHandler<SpecializationsChanged>
    {
        private readonly VacanciesDbContext _context;

        public SpecializationsChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SpecializationsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Specializations
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Specialization>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
