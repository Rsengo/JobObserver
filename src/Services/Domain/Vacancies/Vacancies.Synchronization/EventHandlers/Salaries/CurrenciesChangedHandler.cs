using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Salaries;
using Vacancies.Synchronization.Events.Salaries;

namespace Vacancies.Synchronization.EventHandlers.Salaries
{
    public class CurrenciesChangedHandler :
        IIntegrationEventHandler<CurrenciesChanged>
    {
        private readonly VacanciesDbContext _context;

        public CurrenciesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CurrenciesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Currencies
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Currency>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
