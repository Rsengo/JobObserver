using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using Vacancies.Db;
using Vacancies.Db.Models.Geographic;
using Vacancies.Dto.Models.Geographic;
using Vacancies.Synchronization.Events.Geographic;

namespace Vacancies.Synchronization.EventHandlers.Geographic
{
    public class AreasChangedHandler : IIntegrationEventHandler<AreasChanged>
    {
        private readonly VacanciesDbContext _context;

        public AreasChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AreasChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Area>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt =>
                {
                    opt.MergeKeepIdentity = true;
                    opt.IncludeGraph = true;
                });
        }
    }
}
