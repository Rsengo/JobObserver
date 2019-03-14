using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Languages;
using Vacancies.Dto.Models.Negotiations;
using Vacancies.Dto.Models.Schedules;

namespace Vacancies.Synchronization.Events.Schedules
{
    public class SchedulesChanged : 
        EntityChangedIntegrationEvent<DtoSchedule>
    {
    }
}
