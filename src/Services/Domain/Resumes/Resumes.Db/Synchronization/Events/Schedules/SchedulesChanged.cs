using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Negotiations;
using Resumes.Db.Dto.Models.Schedules;

namespace Resumes.Db.Synchronization.Events.Schedules
{
    public class SchedulesChanged : 
        EntityChangedIntegrationEvent<DtoSchedule>
    {
    }
}
