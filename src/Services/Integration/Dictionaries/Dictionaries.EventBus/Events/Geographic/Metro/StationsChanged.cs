using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Geographic.Metro;

namespace Dictionaries.EventBus.Events.Geographic.Metro
{
    public class StationsChanged : 
        DictionaryChangedIntegrationEvent<DtoStation>
    {
    }
}
