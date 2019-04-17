using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Negotiations;
using Resumes.Db.Dto.Models.Specializations;
using Resumes.Db.Dto.Models.Statuses;

namespace Resumes.Db.Synchronization.Events.Statuses
{
    public class ResumeStatusesChanged : 
        EntityChangedIntegrationEvent<DtoResumeStatus>
    {
    }
}
