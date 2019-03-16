using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Geographic;

namespace Dictionaries.EventBus.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
