using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using CareerDays.Db;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Synchronization.Events;
using CareerDays.Synchronization.Events.Geographic;

namespace CareerDays.Synchronization.EventHandlers
{
    public class EducationalInstitutionsChangedHandler : 
        IIntegrationEventHandler<EducationalInstitutionsChanged>
    {
        private readonly CareerDaysDbContext _context;

        public EducationalInstitutionsChangedHandler(CareerDaysDbContext context)
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
