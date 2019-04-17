using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Models;
using Employers.Db.Synchronization.Events;

namespace Employers.Db.Synchronization.EventHandlers
{
    public class PartnersChangedHandler : 
        IIntegrationEventHandler<PartnersChanged>
    {
        private readonly EmployersDbContext _context;

        public PartnersChangedHandler(EmployersDbContext context)
        {
            _context = context;
        }

        public async Task Handle(PartnersChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Partners
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Partners>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
