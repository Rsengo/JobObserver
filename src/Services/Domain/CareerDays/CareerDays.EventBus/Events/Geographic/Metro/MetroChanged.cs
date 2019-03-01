using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Dto.Models.Geographic.Metro;

namespace CareerDays.Synchronization.Events.Geographic.Metro
{
    public class MetroChanged : 
        EntityChangedIntegrationEvent<DtoMetro>
    {
    }
}
