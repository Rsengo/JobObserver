using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Dto.Models.Geographic;

namespace CareerDays.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoAreaSync>
    {
    }
}
