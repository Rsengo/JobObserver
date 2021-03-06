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
using Resumes.Db.Synchronization.Events.Applicants;
using Resumes.Db.Synchronization.Events.Statuses;

namespace Resumes.Db.Synchronization.EventHandlers.Statuses
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

            await _context.ResumeStatuses
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
