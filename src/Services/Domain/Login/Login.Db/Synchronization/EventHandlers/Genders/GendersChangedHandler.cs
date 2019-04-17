using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Login.Db;
using Login.Db.Models.Genders;
using Login.Db.Synchronization.Events.Genders;

namespace Login.Db.Synchronization.EventHandlers.Genders
{
    public class GendersChangedHandler :
        IIntegrationEventHandler<GendersChanged>
    {
        private readonly LoginDbContext _context;

        public GendersChangedHandler(LoginDbContext context)
        {
            _context = context;
        }

        public async Task Handle(GendersChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Genders
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Gender>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}

