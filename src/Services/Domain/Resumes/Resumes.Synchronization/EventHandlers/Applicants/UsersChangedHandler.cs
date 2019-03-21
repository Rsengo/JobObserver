using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Synchronization.Events.Applicants;

namespace Resumes.Synchronization.EventHandlers.Applicants
{
    public class UsersChangedHandler : 
        IIntegrationEventHandler<UsersChanged>
    {
        private readonly ResumesDbContext _context;

        public UsersChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UsersChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Applicants
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Applicant>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
