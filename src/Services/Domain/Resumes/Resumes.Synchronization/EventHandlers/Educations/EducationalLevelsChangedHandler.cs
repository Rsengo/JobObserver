using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Geographic;
using Resumes.Synchronization.Events.Educations;

namespace Resumes.Synchronization.EventHandlers.Educations
{
    public class EducationalLevelsChangedHandler : 
        IIntegrationEventHandler<EducationalLevelsChanged>
    {
        private readonly ResumesDbContext _context;

        public EducationalLevelsChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EducationalLevelsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<EducationalLevel>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
