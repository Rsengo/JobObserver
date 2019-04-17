using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Skills;
using Resumes.Db.Synchronization.Events.Skills;

namespace Resumes.Db.Synchronization.EventHandlers.Skills
{
    public class SkillsChangedHandler :
        IIntegrationEventHandler<SkillsChanged>
    {
        private readonly ResumesDbContext _context;

        public SkillsChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SkillsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Skills
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Skill>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
