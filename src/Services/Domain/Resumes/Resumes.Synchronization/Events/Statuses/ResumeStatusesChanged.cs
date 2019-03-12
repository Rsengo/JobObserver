using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Languages;
using Resumes.Dto.Models.Negotiations;
using Resumes.Dto.Models.Specializations;
using Resumes.Dto.Models.Statuses;

namespace Resumes.Synchronization.Events.Statuses
{
    public class ResumeStatusesChanged : 
        EntityChangedIntegrationEvent<DtoResumeStatus>
    {
    }
}
