using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Vacancies.Db;
using Vacancies.Db.Models.Driving;
using Vacancies.Db.Models.Geographic;
using Vacancies.Synchronization.Events.Driving;

namespace Vacancies.Synchronization.EventHandlers.Driving
{
    public class DrivingLicenseTypesChangedHandler : 
        IIntegrationEventHandler<DrivingLicenseTypesChanged>
    {
        private readonly VacanciesDbContext _context;

        public DrivingLicenseTypesChangedHandler(VacanciesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DrivingLicenseTypesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.DrivingLicenseTypes
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<DrivingLicenseType>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
