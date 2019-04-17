using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Synchronization.Events.Applicants;
using Resumes.Db.Synchronization.Events.Salaries;

namespace Resumes.Db.Synchronization.EventHandlers.Salaries
{
    public class CurrenciesChangedHandler :
        IIntegrationEventHandler<CurrenciesChanged>
    {
        private readonly ResumesDbContext _context;

        public CurrenciesChangedHandler(ResumesDbContext context)
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
