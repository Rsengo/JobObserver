﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Synchronization.Events.Applicants;

namespace Resumes.Db.Synchronization.EventHandlers.Applicants
{
    public class ApplicantsChangedHandler : 
        IIntegrationEventHandler<ApplicantsChanged>
    {
        private readonly ResumesDbContext _context;

        public ApplicantsChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ApplicantsChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Applicants
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<Applicant>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
