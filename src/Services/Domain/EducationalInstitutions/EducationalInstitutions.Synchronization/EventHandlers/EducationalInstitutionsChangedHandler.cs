using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Synchronization.Events;

namespace EducationalInstitutions.Synchronization.EventHandlers
{
    public class EducationalInstitutionsChangedHandler : 
        IIntegrationEventHandler<EducationalInstitutionsChanged>
    {
        private readonly EducationalInstitutionsDbContext _context;

        public EducationalInstitutionsChangedHandler(EducationalInstitutionsDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EducationalInstitutionsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.EducationalInstitutions
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<EducationalInstitution>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
