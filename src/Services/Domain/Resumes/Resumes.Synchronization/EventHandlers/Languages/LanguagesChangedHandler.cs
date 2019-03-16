using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Languages;
using Resumes.Synchronization.Events.Applicants;
using Resumes.Synchronization.Events.Languages;

namespace Resumes.Synchronization.EventHandlers.Languages
{
    public class LanguagesChangedHandler :
        IIntegrationEventHandler<LanguagesChanged>
    {
        private readonly ResumesDbContext _context;

        public LanguagesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(LanguagesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Languages
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Language>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
