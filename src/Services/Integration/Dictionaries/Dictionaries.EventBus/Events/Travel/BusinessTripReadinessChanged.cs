using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Travel;

namespace Dictionaries.EventBus.Events.Travel
{
    public class BusinessTripReadinessChanged : 
        EntityChangedIntegrationEvent<DtoBusinessTripReadiness>
    {
    }
}
