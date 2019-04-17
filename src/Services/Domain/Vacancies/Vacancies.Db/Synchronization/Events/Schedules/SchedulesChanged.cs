using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Negotiations;
using Vacancies.Db.Dto.Models.Schedules;

namespace Vacancies.Db.Synchronization.Events.Schedules
{
    public class SchedulesChanged : 
        EntityChangedIntegrationEvent<DtoSchedule>
    {
    }
}
