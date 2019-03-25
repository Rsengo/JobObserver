using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using EducationalInstitutions.Db;
using EducationalInstitutions.Db.Models.Geographic;
using EducationalInstitutions.Synchronization.Events.Geographic;

namespace EducationalInstitutions.Synchronization.EventHandlers.Geographic
{
    public class AreasChangedHandler : IIntegrationEventHandler<AreasChanged>
    {
        private readonly EducationalInstitutionsDbContext _context;

        public AreasChangedHandler(EducationalInstitutionsDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AreasChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Area>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt =>
                {
                    opt.MergeKeepIdentity = true;
                    opt.IncludeGraph = true;
                });
        }
    }
}
