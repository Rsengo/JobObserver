using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Schedules;

namespace Dictionaries.EventBus.Events.Schedules
{
    public class SchedulesChanged : 
        DictionaryChangedIntegrationEvent<DtoSchedule>
    {
    }
}
