using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Geographic.Metro;

namespace Dictionaries.EventBus.Events.Geographic.Metro
{
    public class StationsChanged : 
        EntityChangedIntegrationEvent<DtoStation>
    {
    }
}
