using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Models;
using Employers.Synchronization.Events;

namespace Employers.Synchronization.EventHandlers
{
    public class EmployersChangedHandler :
        IIntegrationEventHandler<EmployersChanged>
    {
        private readonly EmployersDbContext _context;

        public EmployersChangedHandler(EmployersDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmployersChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Employers
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Employer>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
