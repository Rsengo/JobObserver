using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Negotiations;
using Vacancies.Db.Synchronization.Events.Negotiations;

namespace Vacancies.Db.Synchronization.EventHandlers.Negotiations
{
    public class ResponsesChangedHandler :
        IIntegrationEventHandler<ResponsesChanged>
    {
        private readonly VacanciesDbContext _context;

        public ResponsesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ResponsesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Responses
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Response>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}

