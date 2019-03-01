using BuildingBlocks.EventBus.Synchronization.Events;
using Employers.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employers.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
