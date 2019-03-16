using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Geographic;
using Resumes.Synchronization.Events.Employments;

namespace Resumes.Synchronization.EventHandlers.Employments
{
    public class EmploymentsChangedHandler :
        IIntegrationEventHandler<EmploymentsChanged>
    {
        private readonly ResumesDbContext _context;

        public EmploymentsChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmploymentsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Employments
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Employment>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}