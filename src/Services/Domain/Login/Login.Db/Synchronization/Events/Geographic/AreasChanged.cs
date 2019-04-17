using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Db.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
