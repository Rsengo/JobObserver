using BuildingBlocks.EventBus.Synchronization.Events;
using Employers.Db.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employers.Db.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
