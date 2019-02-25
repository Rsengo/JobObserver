using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Dto.Models.Geographic.Metro;

namespace CareerDays.EventBus.Events.Dictionaries.Geographic.Metro
{
    public class LinesChanged : 
        DictionaryChangedIntegrationEvent<DtoLine>
    {
    }
}
