using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Synchronization.Events.Applicants;

namespace Resumes.Synchronization.EventHandlers.Applicants
{
    public class GendersChangedHandler :
        IIntegrationEventHandler<GendersChanged>
    {
        private readonly ResumesDbContext _context;

        public GendersChangedHandler(ResumesDbContext context)
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

