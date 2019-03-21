using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
