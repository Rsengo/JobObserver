using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using Employers.Db;
using Employers.Db.Models;
using Employers.Db.Models.Geographic;
using Employers.Synchronization.Events;
using Employers.Synchronization.Events.Geographic;

namespace Employers.Synchronization.EventHandlers
{
    public class EmployerTypesChangedHandler : IIntegrationEventHandler<EmployerTypesChanged>
    {
        private readonly EmployersDbContext _context;

        public EmployerTypesChangedHandler(EmployersDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmployerTypesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.EmployerTypes
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<EmployerType>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
