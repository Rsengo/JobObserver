using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Employers.Db;
using Employers.Db.Models.EducationalInstitutions;
using Employers.Synchronization.Events.EducationalInstitutions;

namespace Employers.Synchronization.EventHandlers.EducationalInstitutions
{
    public class EducationalInstitutionsChangedHandler : 
        IIntegrationEventHandler<EducationalInstitutionsChanged>
    {
        private readonly EmployersDbContext _context;

        public EducationalInstitutionsChangedHandler(EmployersDbContext context)
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
