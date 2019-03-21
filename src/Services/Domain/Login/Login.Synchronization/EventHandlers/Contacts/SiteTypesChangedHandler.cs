using System;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Login.Db;
using System.Threading.Tasks;
using Login.Synchronization.Events.Contacts;
using Login.Db.Models.Contacts;

namespace Login.Synchronization.EventHandlers.Contacts
{
    public class SiteTypesChangedHandler :
        IIntegrationEventHandler<SiteTypesChanged>
    {
        private readonly LoginDbContext _context;

        public SiteTypesChangedHandler(LoginDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SiteTypesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.SiteTypes
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<SiteType>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
