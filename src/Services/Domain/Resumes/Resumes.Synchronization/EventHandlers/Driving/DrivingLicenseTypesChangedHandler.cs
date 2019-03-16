using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Geographic;
using Resumes.Synchronization.Events.Driving;

namespace Resumes.Synchronization.EventHandlers.Driving
{
    public class DrivingLicenseTypesChangedHandler : 
        IIntegrationEventHandler<DrivingLicenseTypesChanged>
    {
        private readonly ResumesDbContext _context;

        public DrivingLicenseTypesChangedHandler(ResumesDbContext context)
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
