using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db;
using Vacancies.Db.Models.Geographic.Metro;
using Vacancies.Dto.Models.Geographic.Metro;
using Vacancies.Synchronization.Events.Geographic.Metro;

namespace Vacancies.Synchronization.EventHandlers.Geographic.Metro
{
    public class MetroChangedHandler : 
        IIntegrationEventHandler<MetroChanged>
    {
        private readonly VacanciesDbContext _context;

        public MetroChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MetroChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Metro
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Db.Models.Geographic.Metro.Metro>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
