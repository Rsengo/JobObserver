using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Languages;
using Dictionaries.Db.Dto.Models.Negotiations;
using Dictionaries.Db.Dto.Models.Schedules;

namespace Dictionaries.Db.Synchronization.Events.Schedules
{
    public class SchedulesChanged : 
        EntityChangedIntegrationEvent<DtoSchedule>
    {
    }
}
