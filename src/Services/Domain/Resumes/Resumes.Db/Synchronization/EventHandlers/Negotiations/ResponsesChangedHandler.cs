using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Synchronization.Events.Applicants;
using Resumes.Db.Synchronization.Events.Negotiations;

namespace Resumes.Db.Synchronization.EventHandlers.Negotiations
{
    public class ResponsesChangedHandler :
        IIntegrationEventHandler<ResponsesChanged>
    {
        private readonly ResumesDbContext _context;

        public ResponsesChangedHandler(ResumesDbContext context)
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

