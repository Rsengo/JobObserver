using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Travel;

namespace Dictionaries.Db.Synchronization.Events.Travel
{
    public class BusinessTripReadinessChanged : 
        EntityChangedIntegrationEvent<DtoBusinessTripReadiness>
    {
    }
}
