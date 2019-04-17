using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Languages;
using Vacancies.Db.Synchronization.Events.Languages;

namespace Vacancies.Db.Synchronization.EventHandlers.Languages
{
    public class LanguagesChangedHandler :
        IIntegrationEventHandler<LanguagesChanged>
    {
        private readonly VacanciesDbContext _context;

        public LanguagesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(LanguagesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Languages
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Language>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
