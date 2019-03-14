using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Geographic;
using Vacancies.Db.Models.Industries;
using Vacancies.Synchronization.Events.Applicants;
using Vacancies.Synchronization.Events.Industries;

namespace Vacancies.Synchronization.EventHandlers.Industries
{
    public class IndustriesChangedHandler :
        IIntegrationEventHandler<IndustriesChanged>
    {
        private readonly VacanciesDbContext _context;

        public IndustriesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(IndustriesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Industry>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}