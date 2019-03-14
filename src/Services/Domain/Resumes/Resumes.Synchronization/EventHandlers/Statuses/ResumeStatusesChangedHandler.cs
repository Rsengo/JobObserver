﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Resumes.Db;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Models.Statuses;
using Resumes.Synchronization.Events.Applicants;
using Resumes.Synchronization.Events.Statuses;

namespace Resumes.Synchronization.EventHandlers.Statuses
{
    public class ResumeStatusesChangedHandler :
        IIntegrationEventHandler<ResumeStatusesChanged>
    {
        private readonly ResumesDbContext _context;

        public ResumeStatusesChangedHandler(ResumesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ResumeStatusesChanged @event)
        {
            var deleted = @event.Deleted;

            await _context.Areas
                .Where(x => deleted.Contains(x.Id))
                .DeleteFromQueryAsync();

            var toMergeDto = @event.Created.Concat(@event.Updated);
            var toMerge = toMergeDto
                .Select(Mapper.Map<ResumeStatus>)
                .ToList();

            await _context.BulkMergeAsync(
                toMerge,
                opt => opt.MergeKeepIdentity = true);
        }
    }
}
